using Business.Constants;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class ToDoValidator : AbstractValidator<ToDo>
    {
        public ToDoValidator()
        {
            When(t => t.Status == true, () =>
            {
                RuleFor(t => t.Title).NotEmpty().WithMessage(Messages.ToDoTitleNotEmpty);
                RuleFor(t => t.Title).MaximumLength(75).WithMessage(Messages.ToDoListedMaxLength);
                RuleFor(t => t.Title).MinimumLength(5).WithMessage(Messages.ToDoListedMinLength);
                RuleFor(t => t.Description).NotEmpty().WithMessage(Messages.ToDoDescriptionNotEmpty);
            });
        }
    }
}
