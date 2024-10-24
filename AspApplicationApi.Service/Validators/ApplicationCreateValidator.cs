using AspApplication.Application.Contracts;
using FluentValidation;
namespace AspApplication.Application.Validators;

public class ApplicationCreateValidator : AbstractValidator<ApplicationDTO>
{
    public ApplicationCreateValidator()
    {
        RuleFor(x => x.Author).NotEmpty().WithMessage("нельзя создать заявку не указав идентификатор пользователя");

        RuleFor(x => x).Must(
       x => x.Type is not null
                  || string.IsNullOrEmpty(x.Name) is false
                  || string.IsNullOrEmpty(x.Description) is false
                  || string.IsNullOrEmpty(x.Outline) is false
       ).WithMessage("нельзя создать заявку не указав хотя бы еще одно поле помимо идентификатора пользователя");
    }
}
