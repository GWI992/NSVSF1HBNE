using FluentValidation;
using Endpoint.Models.Data;
using Endpoint.Repositories.Interfaces;

namespace Endpoint.Validators
{
    public class TableValidator : AbstractValidator<Table>
    {
        public TableValidator(ITableRepository repository)
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(50);
            RuleFor(x => x)
                .Must(x => !repository.ReadAll().Any(item => item.Name == x.Name && item.Id != x.Id && x.Id != null))
                .WithMessage("Table already exists");
            RuleFor(x => x.Capacity)
                .NotEmpty()
                .InclusiveBetween(1, 4);
        }
    }
}
