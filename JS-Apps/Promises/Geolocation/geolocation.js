var mapTools = {},
    progressBar = document.getElementById('progressBar'),
    getLocation = new Promise((resolve) => {
        if (navigator.geolocation) {
            progressBar.innerHTML = 'Loading map...';
            navigator.geolocation.getCurrentPosition((pos) => {
                resolve(pos);
            }, () => {
                progressBar.innerHTML = 'Location tracking declined by user!';
            });
        } else {
            progressBar.innerHTML = 'Location services are disabled on your browser!';
        }
    });

function generateMap(position) {
    progressBar.innerHTML = '';
    mapTools.position = { lat: position.coords.latitude, lng: position.coords.longitude }
    mapTools.map = new google.maps.Map(document.getElementById('map'), {
        center: mapTools.position,
        zoom: 17
    });
}

function generateMarker() {
    mapTools.marker = new google.maps.Marker({
        position: mapTools.position,
        map: mapTools.map,
        title: 'Home, sweet home!'
    });
}

function generateInfoWindow() {
    mapTools.infoWindow = new google.maps.InfoWindow({
        content: "Home, sweet home!"
    });
}

function applyAnimeAndWindow() {
    mapTools.marker.setAnimation(google.maps.Animation.BOUNCE);
    mapTools.marker.addListener('click', () => {
        mapTools.marker.setAnimation(null);
        mapTools.infoWindow.open(mapTools.map, mapTools.marker);
    });
}

function errorHandler(error) {
    console.log(error);
    progressBar.innerHTML = 'The map could not be loaded! Please try again later!';
}

getLocation
    .then(generateMap)
    .then(generateMarker)
    .then(generateInfoWindow)
    .then(applyAnimeAndWindow)
    .catch(errorHandler);