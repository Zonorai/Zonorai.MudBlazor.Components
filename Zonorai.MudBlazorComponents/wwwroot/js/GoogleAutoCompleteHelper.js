async function queryGoogleAutoComplete(query){
    if(!query){
        return null;
    }
    let autoCompleteService = new google.maps.places.AutocompleteService();
    var request = {
        "input":query
    };
    var response = await autoCompleteService.getPlacePredictions(request,null);
    return response;
}
function geoCodeFromId(placeId)
{
    if(!placeId){
        return null;
    }
    var request = {
        placeId:placeId
    };
    return geocode(request);
}
function geoCodeFromText(text) {
    if (!text) {
        return null;
    }
    var request = {
        address: text
    };
    return geocode(request);
}
async function geocode(request) {
    var geocoder = new google.maps.Geocoder();
    var value = await geocoder.geocode(request);
    var json = JSON.stringify(value, null, 2);
    return json;
   
}