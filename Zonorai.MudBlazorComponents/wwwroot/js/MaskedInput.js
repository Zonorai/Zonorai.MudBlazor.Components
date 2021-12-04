window.mask = (id, mask, isRegEx, dotnetHelper) => {
    var pattern;
    if (isRegEx)
        pattern = new RegExp(mask);
    else
        pattern = mask;
    var customMask = IMask(
        document.getElementById(id), {
            mask: pattern,
            commit: function (value, masked) {
                dotnetHelper.invokeMethodAsync('returnUnmaskedValue', this.unmaskedValue);
            }
        });
};
window.creditCardMask = (dotnetHelper) => {


    var cleave = new Cleave("input[data-creditcard]", {
        creditCard: true,
        onCreditCardTypeChanged: function (type) {
            dotnetHelper.invokeMethodAsync('CreditCardTypeChanged',type);
        }
    });


};
window.creditCardDateMask = () =>{


    var cleave = new Cleave('input[data-creditcarddate]', {
        date: true,
        datePattern: ['m', 'y']
    });


};