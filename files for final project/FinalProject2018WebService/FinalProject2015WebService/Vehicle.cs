using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Timers;



namespace FinalProject2015WebService
{
    public class Vehicle
    {
        public int position;
        public string name;
        private static Random Rand = new Random();

        public Vehicle(string Name)
        {
            name = Name;
            Timer timer = new Timer();
            timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
            timer.Interval = Rand.Next(25, 100);  // random speed
            timer.Enabled = true;
            position = Rand.Next(0, GPS_Data.DataCnt);// start at random position
        }
        private void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (++position >= GPS_Data.DataCnt)    // Total number of values in array
                  position = 0;
        }
    }
}