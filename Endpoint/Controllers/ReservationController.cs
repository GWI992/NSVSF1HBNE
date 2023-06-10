using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Endpoint.Logic.Interfaces;
using Endpoint.Models.Data;
using Endpoint.Controllers.GenericControllers;
using Endpoint.Logic.Exceptions;
using Microsoft.AspNetCore.Authorization;

namespace Endpoint.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ReservationController : GenericBaseController<Reservation, Reservation>
    {
        public ReservationController(ILogic<Reservation, Reservation> logic, IValidator<Reservation> validator) : base(logic, validator)
        {
        }
    }
}