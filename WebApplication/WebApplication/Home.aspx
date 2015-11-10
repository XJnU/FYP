<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="WebApplication.Home" MasterPageFile="Site1.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="master.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="http://google-maps-utility-library-v3.googlecode.com/svn/trunk/markerclusterer/src/markerclusterer.js"></script>
    <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?libraries=visualization"></script>
    <script type="text/javascript">
        var pointsArr;
        var marker, i;
        var map;
        var src = "";
        //var mcOptions = { gridSize: 50, maxZoom: 15 };

        function initMap() {
            map = new google.maps.Map(document.getElementById('map'),
            {
                center: new google.maps.LatLng(1.3628862, 103.8490833),
                zoom: 11,
                mapTypeId: google.maps.MapTypeId.ROADMAP
            });
            var ctaLayer = new google.maps.KmlLayer({
                url: 'https://www.dropbox.com/s/m8i06few8iblwke/MP14_SUBZONE_WEB_PL.kml'
            });
            ctaLayer.setMap(map);
            //getCluster(pointsArr);
            /* Script manager for heatmap 
            var heatmap = new google.maps.visualization.HeatmapLayer({
                data: pointsArr,        //getPoints(obj)
                map: map
            });*/
            //End 

            

        }

/*      
        function getPoints(obj) {
            json = obj;
            console.log(json);
            pointsArr = [];
            for (var i = 0; i < json.length; i++)
                pointsArr.push(new google.maps.LatLng(json[i].Latitude, json[i].Longitude));
            return pointsArr;
        }
        

        function loadKmlLayer(src, map) {
            var kmlLayer = new google.maps.KmlLayer(src, {
                suppressInfoWindows: false,
                preserveViewport: false,
                //map: map
            });
            alert("loadKmlLayer()");
        }

        function getCluster(obj) {
            json = obj;
            console.log(json);
            pointsArr = [];
            var infowindow = new google.maps.InfoWindow();
            for (i = 0; i < json.length; i++) {
                marker = new google.maps.Marker({
                    position: new google.maps.LatLng(json[i].Latitude, json[i].Longitude),
                    //map: map
                });
                
                google.maps.event.addListener(marker, 'click', (function (marker, i) {
                    return function () {
                        infowindow.setContent(json[i]);
                        infowindow.open(map, marker);
                    }
                })(marker, i));
                pointsArr.push(marker);
            }
            console.log(pointsArr);
            var markerCluster = new MarkerClusterer(map, pointsArr);
            
        }
        
        
*/
    </script>
    <style>
        .content-body {
            margin-left: 200px;
            width: 1000px;
            clear: both;
            background-color: #cecece;
        }

        #map {
            width: 950px;
            height: 500px;
            padding: 5px;
        }
    </style>

    <div class="content-body">
        <div id="map"></div>
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>
