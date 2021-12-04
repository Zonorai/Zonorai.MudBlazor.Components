# Zonorai.MudBlazor.Components
This repository contains generic components I often use regardless of the project

- Credit Card Input
- Credit Card Date Input (MM/YY)
- Masked Input Field
- Docked Fab Button
- Autocomplete Location Field (Google)
- Autocomplete Address Form (Google)
- Autocomplete ISO Countries Field
- Select Field for ISO Countries
- Generic Prompt Dialog

Working on

- Mediatr Form (a form based on a mediatr command as the model)

Example Usages

    <MudAddressForm DetailedForm="false" @bind-Value="Address"></MudAddressForm>
    <AutocompleteLocationField></AutocompleteLocationField>  
    <MaskedInput Mask="/^[1-6]\d{0,5}$/"></MaskedInput>  
    <CreditCardField></CreditCardField>  
    <CreditCardDateField></CreditCardDateField>
    <CountryAutocompleteField></CountryAutocompleteField>
    <DockedFabButton Position="DockedPosition.BottomRight"></DockedFabButton>
_Imports.razor

    @using Zonorai.MudBlazorComponents.Components;  
    @using Zonorai.MudBlazorComponents.Components.MaskedInput;  
    @using Zonorai.MudBlazorComponents.Components.CreditCard;  
    @using Zonorai.MudBlazorComponents.Components.Forms;  
    @using Zonorai.MudBlazorComponents.Components.Addresses;  
    @using Zonorai.MudBlazorComponents.Components.DockedFabButton;  
    @using Zonorai.MudBlazorComponents.Components.Docked;  
    @using Zonorai.MudBlazorComponents.Components.Prompt;

*index.html Imports

    <script src="_content/Zonorai.MudBlazor.Components/js/GoogleAutoCompleteHelper.js"></script>
    <script src="_content/Zonorai.MudBlazor.Components/js/IMask.js"></script>
    <script src="_content/Zonorai.MudBlazor.Components/js/MaskedInput.js"></script>
    <script src="_content/Zonorai.MudBlazor.Components/js/Cleave.js"></script>
    <link href="_content/Zonorai.MudBlazor.Components/paymenticons.css" rel="stylesheet"></link>
    <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?key={Your Api Key}&libraries=places"></script>