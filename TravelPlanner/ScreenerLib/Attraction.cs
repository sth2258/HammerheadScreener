namespace ScreenerLib
{
    public class Attraction
    {
        private string tagKey;
        private string tagValue;
        private string tagName;
        private string nodeId;
        private double nodeLat;
        private double nodeLon;

        public string TagKey
        {
            get
            {
                return tagKey;
            }

            set
            {
                tagKey = value;
            }
        }

        public string TagValue
        {
            get
            {
                return tagValue;
            }

            set
            {
                tagValue = value;
            }
        }

        public string TagName
        {
            get
            {
                return tagName;
            }

            set
            {
                tagName = value;
            }
        }

        public string NodeId
        {
            get
            {
                return nodeId;
            }

            set
            {
                nodeId = value;
            }
        }

        public double NodeLat
        {
            get
            {
                return nodeLat;
            }

            set
            {
                nodeLat = value;
            }
        }

        public double NodeLon
        {
            get
            {
                return nodeLon;
            }

            set
            {
                nodeLon = value;
            }
        }
    }
}