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
    [Route("api/value/{valueId}/value-works")]
    public class ValueWorksController : Controller
    {

        private readonly IMapper mapper;
        private readonly UnitOfWork uow;

        public ValueWorksController(UnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        // GET api/values
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ICollection<ValueWorksResponse>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Get([FromRoute] long valueId)
            => Ok(mapper.Map<ICollection<ValueWorksResponse>>((await uow.Values.GetAsync(valueId)).ValueWorks));             

        // GET api/values/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ValueWorksResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Get([FromRoute] long valueId, [FromRoute] int id)
            => Ok(mapper.Map<ValueWorksResponse>((await uow.Values.GetAsync(valueId)).FindValueWork(id)));

        // POST api/values
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> Post([FromRoute] long valueId, [FromBody] ValueWorksRequest valueWork)
        {

            var actualValue = await uow.Values.GetAsync(valueId);   
            
            var newValueWork = mapper.Map<ValueWork>(valueWork);
            actualValue.ValueWorks.Add(newValueWork);

            await uow.CommitAsync();

            return Ok(newValueWork.Id);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ValueWorksRequest))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> Put([FromRoute] long valueId, [FromRoute] long id, [FromBody] ValueWorksRequest valueWork)
        {
            var actualValue = await uow.Values.GetAsync(valueId);
            
            mapper.Map(valueWork, actualValue.FindValueWork(id));

            uow.Values.Update(actualValue);

            await uow.CommitAsync();

            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ValuesRequest))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> Delete([FromRoute] long valueId, [FromRoute] long id)
        {
            var actualValue = await uow.Values.GetAsync(valueId);            
            actualValue.ValueWorks.Remove(actualValue.FindValueWork(id));

            await uow.CommitAsync();

            return Ok();
        }
    }
}
