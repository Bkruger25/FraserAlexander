function brett(map) {
	//get query string parameter
	function getParameterByName(name) {
            name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
            var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
                results = regex.exec(location.search);
            return results === null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
        }
	var zoom = getParameterByName("zoom");
	var zoomtype = getParameterByName("zoomtype");
	//alert(zoom);
	//alert(zoomtype);
	var lat;
	var lng;
	var point;
	//alert("hi");
	if (zoom == "yes")
	{
	    if (zoomtype == "country")
	    {
	        lat = getParameterByName("lat");
	        console.log(lat);
	        lng = getParameterByName("lng");
	        console.log(lng);
	        console.log("country");
	        point = new esri.geometry.Point(lng, lat);
	        //alert(point.longitude);
	        map.centerAndZoom(point, 6);
	    }
	    else if (zoomtype == "site")
	    {
	        lat = getParameterByName("lat");
	        console.log(lat);
	        lng = getParameterByName("lng");
	        console.log(lng);
	        console.log("site");
	        point = new esri.geometry.Point(lng, lat);
	        //alert(point.longitude);
	        map.centerAndZoom(point, 13);
	    }
	    else if (zoomtype == "mine")
	    {
	        lat = getParameterByName("lat");
	        console.log(lat);
	        lng = getParameterByName("lng");
	        console.log(lng);
	        console.log("mine");
	        point = new esri.geometry.Point(lng, lat);
	        //alert(point.longitude);
	        map.centerAndZoom(point, 8);
	    }
	}	
}		
		
