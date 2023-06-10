using FluentValidation;
using Microsoft.AspNetCore.Mvc;

using Endpoint.Logic.Exceptions;
using Endpoint.Logic.Interfaces;

namespace Endpoint.Controllers.GenericControllers
{
    [Route("[controller]")]
    [ApiController]
    public abstract class GenericBaseController<TReq, TRes> : ControllerBase
    {
        protected ILogic<TReq, TRes> _logic;
        protected IValidator<TReq>? _validator = null;

        public GenericBaseController(ILogic<TReq, TRes> logic, IValidator<TReq> validator)
        {
            _logic = logic;
            _validator = validator;
        }

        public GenericBaseController(ILogic<TReq, TRes> logic) : this(logic, null) { }

        [HttpGet]
        public virtual IEnumerable<TRes> ReadAll()
        {
            return _logic.ReadAll();
        }

        [HttpGet("{id}")]
        public virtual ActionResult<TRes> Read(string id)
        {
            try
            {
                return _logic.Read(id);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound();
            }

        }

        [HttpPost]
        public virtual IResult Create([FromBody] TReq value)
        {
            if (_validator != null && !_validator.Validate(value).IsValid)
            {
                var validationResult = _validator.Validate(value);
                if (!validationResult.IsValid)
                {
                    return Results.ValidationProblem(validationResult.ToDictionary());
                }
            }
            _logic.Create(value);
            return Results.CreatedAtRoute();
        }

        [HttpPut("{id}")]
        public virtual IResult Put(string id, [FromBody] TReq value)
        {
            if (_validator != null && !_validator.Validate(value).IsValid)
            {
                var validationResult = _validator.Validate(value);
                if (!validationResult.IsValid)
                {
                    return Results.ValidationProblem(validationResult.ToDictionary());
                }
            }

            try
            {
                _logic.Update(id, value);
            }
            catch (EntityNotFoundException ex)
            {
                return Results.NotFound();
            }
            return Results.AcceptedAtRoute();
        }

        [HttpDelete("{id}")]
        public virtual void Delete(string id)
        {
            _logic.Delete(id);
        }
    }
}
