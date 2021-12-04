using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MudBlazor;
using Zonorai.MudBlazorComponents.Interop;
using Zonorai.MudBlazorComponents.Models.Google;

namespace Zonorai.MudBlazorComponents.Components.Addresses;

public class AutocompleteLocationField : MudAutocomplete<AutoCompleteQueryResponseItem>
{
#pragma warning disable CS8618
    public AutocompleteLocationField()
#pragma warning restore CS8618
    {
        this.AdornmentIcon = Icons.Material.Filled.Search;
        this.SearchFunc = async (string value) => await CallPlaces(value);
        this.Adornment = Adornment.End;
        this.AdornmentColor = Color.Primary;
        this.ToStringFunc = item => item.Description;
    }
    [Inject]
    protected IJSRuntime jsRuntime { get; set; }
    
    [Inject]
    protected GoogleQueryAutocomplete _queryAuto { get; set; }

    private DateTime? LastInput { get; set; }

    [Parameter]
    public AutoCompleteQueryResponseItem Place { get; set; } = new();

    public List<AutoCompleteQueryResponseItem> LastPredictions { get; set; } = new();

    protected override Task OnInitializedAsync()
    {
        if (Place != null)
        {
            if (Place.PlaceId != null)
            {
                Text = Place.Description;
            }
        }

        return base.OnInitializedAsync();
    }

    private async Task<IEnumerable<AutoCompleteQueryResponseItem>> CallPlaces(string input)
    {
        if (LastInput.HasValue == false)
        {
            LastInput = DateTime.Now;
        }
        if (LastInput.Value.AddSeconds(2.5) > DateTime.Now)
        {
            return new List<AutoCompleteQueryResponseItem>();
        }
        if (input.Length < 3)
        {
            return new List<AutoCompleteQueryResponseItem>();
        }

        var placeNames = await _queryAuto.QueryAutocomplete(input);
        LastPredictions = placeNames.Places.ToList();
        return placeNames.Places.ToList();
    }
}