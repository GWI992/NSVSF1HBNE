﻿using FluentValidation;
using Endpoint.Models.Data;

namespace Endpoint.Validators
{
    public class TableValidator : AbstractValidator<Table>
    {
        public TableValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(50);
        }
    }
}
