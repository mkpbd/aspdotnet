using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TodoItems.UpdateTodoItem
{
    public class UpdateTodoItemCommandValidator : AbstractValidator<UpdateTodoItemCommand>
    {
        public UpdateTodoItemCommandValidator()
        {
            RuleFor(v => v.Title)
                .MaximumLength(200)
                .NotEmpty();
        }
    }

}
