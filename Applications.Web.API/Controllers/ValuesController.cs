using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Domain.Repository;
using Applications.Web.Models.Response;
using AutoMapper;
using Domain.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Application.Web.API.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {

        private readonly IMapper mapper;
        private readonly UnitOfWork uow;

        public ValuesController(UnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        // GET api/values
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ICollection<ValuesResponse>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Get()
            => Ok(mapper.Map<ICollection<ValuesResponse>>(await uow.Values.GetAsync()));        

        // GET api/values/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ValuesResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Get([FromRoute] int id)
            => Ok(mapper.Map<ValuesResponse>(await uow.Values.GetAsync(id)));

        // GET api/values/5
        [HttpGet("get_by_name/{name}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ValuesResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Get([FromRoute] string name)
            => Ok(mapper.Map<ValuesResponse>(await uow.Values.GetByNameAsync(name)));

        // POST api/values
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> Post([FromBody] ValuesRequest value)
        {
            var newValue = mapper.Map<Value>(value);
            uow.Values.Create(newValue);

            await uow.CommitAsync();

            return Ok(newValue.Id);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ValuesRequest))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> Put([FromRoute] long id, [FromBody] ValuesRequest value)
        {
            var currentValue = await uow.Values.GetAsync(id);
            mapper.Map(value, currentValue);

            uow.Values.Update(currentValue);

            await uow.CommitAsync();

            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ValuesRequest))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> Delete([FromRoute] long id)
        {
   
            uow.Values.Remove(await uow.Values.GetAsync(id));

            await uow.CommitAsync();

            return Ok();
        }
    }
}
