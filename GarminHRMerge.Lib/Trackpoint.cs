using System;
using System.Collections.Generic;
using System.Text;

namespace GarminHRMerge.Lib
{
    public class Trackpoint
    {
        public DateTime Time { get; set; }
        public int HeartRateBpm { get; set; }

        public override string ToString()
        {
            return this.HeartRateBpm + " @ " + this.Time.ToLongTimeString();
        }
    }
}
