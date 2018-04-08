using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Data.OleDb;
using System.Text.RegularExpressions;
using System.Text;
using System.Security.Cryptography;

namespace WebApplication18 {
    public class UserHandler {
        public static string AddUser(Page p, string name, string pass) {
            if (name.Length < 3 || name.Length > 20)
                return "Username must be between 3 and 20 characters long";

            if (!Regex.IsMatch(name, "^[a-zA-Z0-9_]*$"))
                return "Username can contain only letters, numbers, and underscores";

            OleDbConnection con = DBHandler.Connect(p);

            OleDbCommand cmd = new OleDbCommand("SELECT COUNT(*) FROM Users WHERE Username=@UN", con);
            cmd.Parameters.Add(new OleDbParameter("UN", name));
            cmd.Connection.Open();
            int count = (int)cmd.ExecuteScalar();

            if (count > 0)
                return "Username is already taken";

            SHA256 mSHA = SHA256Managed.Create();

            cmd = new OleDbCommand("INSERT INTO Users (Username, PassHash) values (@UN, @PH)", con);
            cmd.Parameters.Add(new OleDbParameter("UN", name));
            cmd.Parameters.Add(new OleDbParameter("PH", mSHA.ComputeHash(Encoding.ASCII.GetBytes(pass))));
            cmd.ExecuteNonQuery();

            con.Close();

            return "";
        }

        public static string Login(Page p, string name, string pass) {
            OleDbConnection con = DBHandler.Connect(p);

            SHA256 mSHA = SHA256Managed.Create();

            OleDbCommand cmd = new OleDbCommand("SELECT * FROM Users WHERE Username=@UN AND PassHash=@PH", con);
            cmd.Parameters.Add(new OleDbParameter("UN", name));
            cmd.Parameters.Add(new OleDbParameter("PH", mSHA.ComputeHash(Encoding.ASCII.GetBytes(pass))));
            cmd.Connection.Open();
            
            OleDbDataReader r = cmd.ExecuteReader();

            if (!r.HasRows) {
                con.Close();
                return "Incorrect Username or Password";
            }

            con.Close();
            return "";
        }
    }
}