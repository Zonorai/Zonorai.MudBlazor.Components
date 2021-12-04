using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;

namespace Zonorai.Sandbox.Pages;
public class ModelValidator : AbstractValidator<Model>
{
    public ModelValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is Required").MaximumLength(5)
            .WithMessage("Max Length of 5 only");
    }
}
public class Model : IRequest<int>
{
    public string Name { get; set; }
}
/*public class ModelValidator : AbstractValidator<Model>
{
    public ModelValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is Required").MaximumLength(5)
            .WithMessage("Max Length of 5 only");
        RuleFor(x => x.Amount).GreaterThanOrEqualTo(3).WithMessage("Amount must best greater or equal to 3");
    }
}
public class Model : IRequest<int>
{
    public string Id { get; set; }
    public string Name { get; set; }
    public int Amount { get; set; }
}*/

public class ModelHandler : IRequestHandler<Model, int>
{
    public Task<int> Handle(Model request, CancellationToken cancellationToken)
    {
        return Task.FromResult(2);
    }
}