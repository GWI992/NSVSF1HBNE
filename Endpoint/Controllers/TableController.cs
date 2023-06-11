using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Endpoint.Logic.Interfaces;
using Endpoint.Models.Data;
using Endpoint.Controllers.GenericControllers;
using Microsoft.AspNetCore.Authorization;

namespace Endpoint.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TableController : GenericBaseController<Table, Table>
    {
        public TableController(ILogic<Table, Table> logic, IValidator<Table> validator) : base(logic, validator)
        {
        }

        [Authorize(Roles = "Administrator")]
        public override IResult Create([FromBody] Table value)
        {
            return base.Create(value);
        }

        [Authorize(Roles = "Administrator")]
        public override IResult Put(string id, [FromBody] Table value)
        {
            return base.Put(id, value);
        }

        [Authorize(Roles = "Administrator")]
        public override void Delete(string id)
        {
            base.Delete(id);
        }
    }
}