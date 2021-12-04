namespace Zonorai.MudBlazorComponents.Components.Forms;

public class FluentFormContext<TRequest>
{
    public FluentFormContext(Func<object, string, Task<IEnumerable<string>>> validator,TRequest model)
    {
        Model = model;
        Validator = validator;
    }
    public Func<object, string, Task<IEnumerable<string>>> Validator { get; set; }
    public TRequest Model { get; set; }
}