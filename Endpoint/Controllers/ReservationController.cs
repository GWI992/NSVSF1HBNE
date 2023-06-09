using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Endpoint.Logic.Interfaces;
using Endpoint.Models.Data;
using Endpoint.Controllers.GenericControllers;
using Endpoint.Logic.Exceptions;

namespace Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ReservationController : GenericBaseController<Reservation, Reservation>
    {
        public ReservationController(ILogic<Reservation, Reservation> logic, IValidator<Reservation> validator) : base(logic, validator)
        {
        }
    }
}