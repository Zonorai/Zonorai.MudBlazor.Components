using Zonorai.MudBlazorComponents.Models;

namespace Zonorai.MudBlazorComponents.Components.Addresses;

public class MudAddress
{
    public string PlaceId { get; set; }
    public string ZipCode { get; set; }
    public string StreetAddress { get; set; }
    public string AddressLineTwo { get; set; }
    public Country Country { get; set; }
    public string? CountryCode => Enum.GetName(Country);
    public string Province { get; set; }
    public string City { get; set; }
    public string FormattedAddress { get; set; }
}