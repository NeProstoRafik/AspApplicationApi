using AspApplication.Application.Contracts;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspApplication.Application.Validators;

public class ApplicationUpdateValidator : AbstractValidator<ApplicationDTOUpdate>
{
    public ApplicationUpdateValidator()
    {
        RuleFor(x => x).Must(
           x => x.Type is not null
                || string.IsNullOrEmpty(x.Name) is false
                || string.IsNullOrEmpty(x.Description) is false
                || string.IsNullOrEmpty(x.Outline) is false
       ).WithMessage("нельзя отредактировать заявку так, чтобы  в ней не остались заполненными идентификатор пользователя + еще одно поле");
    }
}
