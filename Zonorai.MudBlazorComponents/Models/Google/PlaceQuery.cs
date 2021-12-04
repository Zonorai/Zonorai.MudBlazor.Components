using System.Text.Json.Serialization;
using Newtonsoft.Json;

/*From https://github.com/vivet/GoogleApi*/
namespace Zonorai.MudBlazorComponents.Models.Google
{
    public class AutoCompleteQueryResponse
    {
        [JsonProperty("predictions")]
        [JsonPropertyName("predictions")]
        public AutoCompleteQueryResponseItem[] Places { get; set; }
    }
    public class AutoCompleteQueryResponseItem
    {
        [JsonProperty("place_id")]
        [JsonPropertyName("place_id")]
        public string PlaceId { get; set; }
        [JsonProperty("description")]
        [JsonPropertyName("description")]
        public string Description { get; set; }
    }
}