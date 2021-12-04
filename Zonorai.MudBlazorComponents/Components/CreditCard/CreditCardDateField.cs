using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MudBlazor;

namespace Zonorai.MudBlazorComponents.Components.CreditCard;

public class CreditCardDateField : MudTextField<string>
{
    [Inject] protected IJSRuntime _jsRuntime { get; set; }

    public CreditCardDateField()
    {
        if (UserAttributes != null)
        {
            UserAttributes.Add("data-creditcarddate", "true");
        }
        Placeholder = "MM/YY";
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            await _jsRuntime.InvokeVoidAsync("creditCardDateMask");
        }

        await base.OnAfterRenderAsync(firstRender);
    }
}