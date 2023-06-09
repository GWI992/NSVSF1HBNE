using FluentValidation;
using Endpoint.Models.Data;
using Endpoint.Repositories.GenericRepository;
using Endpoint.Repositories.Interfaces;

namespace Endpoint.Validators
{
    public class ReservationValidator : AbstractValidator<Reservation>
    {
        public ReservationValidator(ITableRepository repository)
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(50);
            RuleFor(x => x.Contact)
                .NotEmpty();
            RuleFor(x => x.Begin)
                .NotEmpty();
            RuleFor(x => x.End)
                .NotEmpty()
                .GreaterThan(x => x.Begin);
            RuleFor(x => x.TableId)
                .NotEmpty()
                .Must(tableId => repository.ReadAll().Any(item => item.Id == tableId))
                .WithMessage("Table does not exists.");
            RuleFor(x => x.Person)
                .GreaterThanOrEqualTo(1);
        }
    }
}
