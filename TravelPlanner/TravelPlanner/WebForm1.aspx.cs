using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelPlanner
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack) {
                string script = @"<script>$(document).ready(function(){
 var mymap = L.map('mapid').setView([40.7588954, -73.9903364], 13);
L.tileLayer('http://{s}.tile.osm.org/{z}/{x}/{y}.png', {}).addTo(mymap);

});
</script>";

            Page.ClientScript.RegisterStartupScript(this.GetType(), "myKey", script, false);
                }
        }

        protected void go_Click(object sender, EventArgs e)
        {
            string[] source = sourceCoords.Text.Trim().Split(',');
            string[] dest = destCoords.Text.Trim().Split(',');

            ScreenerLib.OSMMap osm = new ScreenerLib.OSMMap(Server.MapPath("~/map.xml"), new string[] { "tourism", "attraction", "leisure", "natural" });
            List<ScreenerLib.Attraction> attractionList = osm.GetAllAttractions();
            // 40.746366, -74.001142, 40.762195, -73.972364
            List<ScreenerLib.Attraction> nearbyAttrs = osm.GetNearbyAttractions(attractionList, double.Parse(source[0]), double.Parse(source[1]), double.Parse(dest[0]), double.Parse(dest[1]));
            string script = @"<script>$(document).ready(function(){
 var mymap = L.map('mapid').setView([40.7588954, -73.9903364], 13);
L.tileLayer('http://{s}.tile.osm.org/{z}/{x}/{y}.png', {}).addTo(mymap);

L.marker([" + source[0] + "," + source[1] + @"]).addTo(mymap)
    .bindPopup('Start')
    .openPopup();

L.marker([" + dest[0] + "," + dest[1] + @"]).addTo(mymap)
    .bindPopup('Destination')
    .openPopup();";
            foreach(ScreenerLib.Attraction attr in nearbyAttrs)
            {
                script+= @"
L.marker([" + attr.NodeLat + "," + attr.NodeLon + @"]).addTo(mymap)
    .bindPopup('"+ HttpUtility.HtmlEncode(attr.TagName) + @"');";

            }
script+=@"
});
</script>";

            Page.ClientScript.RegisterStartupScript(this.GetType(), "myKey", script, false);
        }
    }
}