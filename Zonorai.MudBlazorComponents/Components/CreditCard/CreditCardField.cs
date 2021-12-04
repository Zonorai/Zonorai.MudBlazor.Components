using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MudBlazor;
using Zonorai.MudBlazorComponents.Models;

namespace Zonorai.MudBlazorComponents.Components.CreditCard;

public class CreditCardField : MudTextField<string>
{
    [Inject] protected IJSRuntime _jsRuntime { get; set; }

    private string _creditCardIcon { get; set; } = Icons.Material.Filled.CreditCard;

    public CreditCardField()
    {
        this.Adornment = Adornment.End;
        this.AdornmentIcon = _creditCardIcon;
        this.AdornmentColor = Color.Primary;
        this.InputType = InputType.Text;
        if (UserAttributes != null)
        {
            UserAttributes.Add("data-creditcard", "true");
        }
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            await _jsRuntime.InvokeVoidAsync("creditCardMask", DotNetObjectReference.Create(this));
        }

        await base.OnAfterRenderAsync(firstRender);
    }

    //Type to IRL Type mapping
    /*
     Mastercard = maestro,
     American Express = amex,
     Visa = visa
     Diners Club =  diners,
     Discover = discover
     JCB = jcb
     */

    [JSInvokable]
    public void CreditCardTypeChanged(string type)
    {
        switch (type)
        {
            case "unknown":
                _creditCardIcon = Icons.Material.Filled.CreditCard;
                break;
            case "maestro":
                _creditCardIcon = PaymentIcons.Maestro;
                break;
            case "amex":
                _creditCardIcon = PaymentIcons.AmericanExpress;
                break;
            case "visa":
                _creditCardIcon = PaymentIcons.Visa;
                break;
            case "diners":
                _creditCardIcon = PaymentIcons.Diners;
                break;
            case "jcb":
                _creditCardIcon = PaymentIcons.JCB;
                break;
        }

        this.AdornmentIcon = _creditCardIcon;
        StateHasChanged();
    }
}