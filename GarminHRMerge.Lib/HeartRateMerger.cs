using System;
using System.Xml;
using System.Xml.Linq;
using System.Linq;
using System.Collections.Generic;

namespace GarminHRMerge.Lib
{
    public static class HeartRateMerger
    {
        public static List<Trackpoint> GetGarminTrackpoints(string path)
        {
            XDocument xml = XDocument.Load(path);
            var trackpoints = xml.Descendants().Where(w => w.Name.LocalName == "Trackpoint").ToList();

            var tpList = new List<Trackpoint>();

            foreach(var trackpoint in trackpoints)
            {
                tpList.Add(new Trackpoint
                {
                    Time = DateTime.Parse(trackpoint.Elements().Where(w => w.Name.LocalName == "Time").FirstOrDefault().Value).ToUniversalTime(),
                    HeartRateBpm = int.Parse(trackpoint.Elements().Where(w => w.Name.LocalName == "HeartRateBpm").FirstOrDefault().Value)
                });
            }
            return tpList;
        }

        public static XElement GetNearestElement(XDocument xml, DateTime timestamp)
        {
            var trackpoints = xml.Descendants().Where(w => w.Name.LocalName == "Trackpoint").ToList();

            throw new NotImplementedException();
        }
    }
}
