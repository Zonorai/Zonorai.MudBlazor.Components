using EnumsNET;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using Zonorai.MudBlazorComponents.Interop;
using Zonorai.MudBlazorComponents.Models;

namespace Zonorai.MudBlazorComponents.Components.AutocompleteLocation;

public class CountryAutocompleteField : MudAutocomplete<Country>
{
    public CountryAutocompleteField()
    {
        this.AdornmentIcon = Icons.Material.Filled.Search;
        this.SearchFunc = async (string value) => await CallPlaces(value);
        this.Adornment = Adornment.End;
        this.AdornmentColor = Color.Primary;
        this.ToStringFunc = item => item.AsString(EnumFormat.Description);
    }
    
    private List<Country> CountryList => Enum.GetValues<Country>().ToList();
    [Parameter] public Country Country { get; set; } = new();

    public List<Country> LastPredictions { get; set; } = new();

    protected override Task OnInitializedAsync()
    {

        return base.OnInitializedAsync();
    }

    private async Task<IEnumerable<Country>> CallPlaces(string input)
    {
        string lowerInput = input.ToLower();
        return CountryList.Where(x => x.AsString(EnumFormat.Description).ToLower().Contains(lowerInput)).ToList();
    }
}