<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="TravelPlanner.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Scripts/jquery-1.10.2.js" type="text/javascript"></script>
    <link rel="stylesheet" href="https://unpkg.com/leaflet@1.1.0/dist/leaflet.css" />
    <script src="https://unpkg.com/leaflet@1.1.0/dist/leaflet.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <style>#mapid { width:65%;height: 800px; float:right}</style>
    
        <div>
            <asp:Literal ID="Literal1" runat="server"></asp:Literal>
        <div style="float:left"><br /><br />
        Source Latitude/Longitude: <asp:TextBox ID="sourceCoords" runat="server"></asp:TextBox><br /><br />
        Destination Latitude/Longitude: <asp:TextBox ID="destCoords" runat="server"></asp:TextBox><br /><br /><br />
            <asp:Button ID="go" runat="server" Text="Find me attractions!" OnClick="go_Click" />
            </div>
<div id="mapid"></div>
            </div>
    </div>
    </form>
</body>
</html>
