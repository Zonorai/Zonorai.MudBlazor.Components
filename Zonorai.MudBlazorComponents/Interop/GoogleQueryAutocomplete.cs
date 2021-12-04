using System;
using System.Threading;
using System.Threading.Tasks;
using Geo.Google.Models.Responses;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Zonorai.MudBlazorComponents.Models.Google;

namespace Zonorai.MudBlazorComponents.Interop
{
    public class GoogleQueryAutocomplete
    {
        private readonly IJSRuntime _jsRuntime;

        public GoogleQueryAutocomplete(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task<AutoCompleteQueryResponse> QueryAutocomplete(string input,CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new Exception("Cannot Query a null value");
            }

            var response = await _jsRuntime.InvokeAsync<AutoCompleteQueryResponse>("queryGoogleAutoComplete", cancellationToken, input);
            return response;
        }
        public async Task<GeocodingResponse> GetGeoCodingFromPlaceId(string placeId,CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(placeId))
            {
                throw new Exception("Cannot Query a null value");
            }

            var response = await _jsRuntime.InvokeAsync<string>("geoCodeFromId", cancellationToken, placeId);
            return JsonConvert.DeserializeObject<GeocodingResponse>(response) ?? throw new InvalidOperationException();
        }
        
        public async Task<GeocodingResponse> GetGeoCodingFromAddress(string address,CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(address))
            {
                throw new Exception("Cannot Query a null value");
            }
            var response = await _jsRuntime.InvokeAsync<string>("geoCodeFromText", cancellationToken, address);
            return JsonConvert.DeserializeObject<GeocodingResponse>(response) ?? throw new InvalidOperationException();
        }
    }
}