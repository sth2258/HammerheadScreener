using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.XPath;

namespace ScreenerLib
{    
    public class OSMMap
    {
        #region globals
        private string osmXmlFile;
        private string[] attractionTypes;
        #endregion

        #region getters/setters
        public string OsmXmlFile
        {
            get
            {
                return osmXmlFile;
            }

            set
            {
                osmXmlFile = value;
            }
        }
        

        public string[] AttractionTypes
        {
            get
            {
                return attractionTypes;
            }

            set
            {
                attractionTypes = value;
            }
        }
#endregion


        #region Constructors


        public OSMMap(string osmXMLFile, string[] attractionTypes)
        {
            this.OsmXmlFile = osmXMLFile;
            this.AttractionTypes = attractionTypes;

        }


        #endregion

        #region methods
        public List<Attraction> GetAllAttractions()
        {
            List<Attraction> attractions = new List<Attraction>();
            XmlDocument doc = new XmlDocument();
            doc.Load(this.OsmXmlFile);
            XmlElement root = doc.DocumentElement;
            //quick and dirty - construct the xpath string and remove the tailing | 
            string xPath = "";
            foreach(string attraction in AttractionTypes)
            {
                xPath += "/osm/node/tag[@k='" + attraction + "']|";
            }
            xPath = xPath.Remove(xPath.Length - 1);

            var elements = root.SelectNodes(xPath);
            foreach (XmlElement element in elements)
            {
                Attraction tmpAttr = new Attraction();
                tmpAttr.TagKey = element.Attributes["k"].Value;
                tmpAttr.TagValue = element.Attributes["v"].Value;
                tmpAttr.NodeId = element.ParentNode.Attributes["id"].Value;
                tmpAttr.NodeLat = double.Parse(element.ParentNode.Attributes["lat"].Value);
                tmpAttr.NodeLon = double.Parse(element.ParentNode.Attributes["lon"].Value);
                try { tmpAttr.TagName = element.ParentNode.SelectSingleNode("./tag[@k='name']").Attributes["v"].Value; } catch { tmpAttr.TagName = "No Name"; }
                attractions.Add(tmpAttr);
            }

            return attractions;
        }

        public List<Attraction> GetNearbyAttractions(List<Attraction> allAttractions, double sourceLat, double sourceLon, double destLat, double destLon)
        {
            List<Attraction> attractions = new List<Attraction>();
            //essentilly, make a square - between source lat
            
            double boundEast = double.NaN, boundWest = double.NaN, boundNorth = double.NaN, boundSouth = double.NaN;
            //determine the longitudinal preference from the starting and ending points
            if (sourceLon > destLon) { boundEast = sourceLon; boundWest = destLon; }
            if (sourceLon < destLon) { boundEast = destLon; boundWest = sourceLon; }
            if(sourceLon == destLon) { boundEast = sourceLon; boundWest = destLon; }

            //do the same with the latitudinal points
            if (sourceLat > destLat) { boundNorth = sourceLat; boundSouth = destLat; }
            if (sourceLat < destLat) { boundNorth = destLat; boundSouth = sourceLat; }
            if (sourceLat == destLat) { boundNorth = sourceLat; boundSouth = destLat; }

            //now, use a Linq where clause to pull out all entries that fall within - calculated as:
            // >=east && <=west && >=south && <= north
            foreach(Attraction att in allAttractions)
            {
                
                if((att.NodeLon >= boundWest && att.NodeLon <= boundEast) && (att.NodeLat >= boundSouth && att.NodeLat <= boundNorth)) { attractions.Add(att); }
            }


            return attractions;
        }

        #endregion
    }
}
