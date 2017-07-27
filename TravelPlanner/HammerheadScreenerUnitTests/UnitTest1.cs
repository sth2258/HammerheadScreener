using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace HammerheadScreenerUnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGetAllAttractions()
        {
            ScreenerLib.OSMMap osm = new ScreenerLib.OSMMap(@"..\..\..\map.xml", new string[] {"tourism","attraction","leisure","natural" });
            List<ScreenerLib.Attraction> attractionList = osm.GetAllAttractions();

            Assert.AreNotEqual(attractionList.Count, 0);

        }

        [TestMethod]
        public void TestGetSpeficicAttractionsOnRoute()
        {
            ScreenerLib.OSMMap osm = new ScreenerLib.OSMMap(@"..\..\..\map.xml", new string[] { "tourism", "attraction", "leisure", "natural" });
            List<ScreenerLib.Attraction> attractionList = osm.GetAllAttractions();

            List<ScreenerLib.Attraction> nearbyAttrs = osm.GetNearbyAttractions(attractionList, 40.746366, -74.001142, 40.762195, -73.972364);

            Assert.AreNotEqual(attractionList.Count, 0);

        }
    }
}
