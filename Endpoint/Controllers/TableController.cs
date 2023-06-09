using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Endpoint.Logic.Interfaces;
using Endpoint.Models.Data;
using Endpoint.Controllers.GenericControllers;

namespace Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TableController : GenericBaseController<Table, Table>
    {
        public TableController(ILogic<Table, Table> logic, IValidator<Table> validator) : base(logic, validator)
        {
        }
    }
}