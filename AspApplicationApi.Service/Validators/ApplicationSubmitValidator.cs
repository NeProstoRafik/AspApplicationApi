using FluentValidation;
using AspApplication.Domain.Entity;
namespace AspApplication.Application.Validators;

public class ApplicationSubmitValidator :AbstractValidator<AspApplication.Domain.Entity.Application>
{
    public ApplicationSubmitValidator()
    {
        RuleFor(a => a.Autor).NotEmpty();
        RuleFor(a => a.Type).NotEmpty();
        RuleFor(a => a.Name).NotEmpty();
        RuleFor(a => a.Description).NotEmpty();
        RuleFor(a => a.Outline).NotEmpty();
    }    
}
