using GarminHRMerge.Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace GarminHRMerge.Test
{
    [TestClass]
    public class HeartRateMergerTest
    {
        [DataTestMethod]
        [DataRow(@"d:\Garmin\garmin\activity_3422755503.tcx")]
        public void GetGarminTrackpoints_Test(string path)
        {
            HeartRateMerger.GetGarminTrackpoints(path);
        }

        [DataTestMethod]
        [DataRow(@"d:\Garmin\garmin\activity_3422755503.tcx", @"D:\Garmin\concept2\activity_3422757338.tcx")]
        public void GetNearestElement_Test(string garminPath, string concept2Path)
        {
            var trackpoints = HeartRateMerger.GetGarminTrackpoints(garminPath);
            foreach(var trackpoint in trackpoints)
            {
                System.Xml.Linq.XDocument xml = System.Xml.Linq.XDocument.Load(concept2Path);
                var element = HeartRateMerger.GetNearestElement(xml, trackpoint.Time);
                string stop = "stop";
            }

        }
    }
}
