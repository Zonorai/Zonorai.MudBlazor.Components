using Geo.Google.Enums;
using Geo.Google.Models.Responses;
using Zonorai.MudBlazorComponents.Components.Addresses;
using Zonorai.MudBlazorComponents.Models;
using Zonorai.MudBlazorComponents.Models.Google;

namespace Zonorai.MudBlazorComponents.Extensions;

public static class GoogleExtensions
{
    public static AutoCompleteQueryResponseItem ToAutoCompleteQueryResponseItem(this MudAddress response)
    {
        AutoCompleteQueryResponseItem responseItem = new AutoCompleteQueryResponseItem();
        responseItem.Description = response.FormattedAddress;
        responseItem.PlaceId = response.PlaceId;
        return responseItem;
    }

    public static MudAddress ToMudAddress(this GeocodingResponse response)
    {
        MudAddress mudAddress = new MudAddress();
        var result = response.Results.First();
        string streetNumber = string.Empty;
        string route = string.Empty;
        foreach (var component in result.AddressComponents)
        {
            if (component.Types.Any(x => x == AddressType.Sublocality))
            {
                mudAddress.City = component.LongName;
            }

            if (component.Types.Any(x => x == AddressType.Country))
            {
                mudAddress.Country = Enum.Parse<Country>(component.ShortName);
            }

            if (component.Types.Any(x => x == AddressType.AdministrativeArea1))
            {
                mudAddress.Province = component.LongName;
            }
            if (component.Types.Any(x => x == AddressType.PostalCode))
            {
                mudAddress.ZipCode = component.ShortName;
            }
            if (component.Types.Any(x => x == AddressType.Route))
            {
                route = component.ShortName;
            }
            if (component.Types.Any(x => x == AddressType.StreetNumber))
            {
                streetNumber = component.ShortName;
            }
        }

        mudAddress.PlaceId = result.PlaceId;
        mudAddress.StreetAddress = $"{streetNumber} {route}";
        mudAddress.FormattedAddress = result.FormattedAddress;
        return mudAddress;
    }
}