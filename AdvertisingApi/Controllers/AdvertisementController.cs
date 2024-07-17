using AdvertisingApi.CQRS.Commands.CreateAdvertisement;
using AdvertisingApi.CQRS.Queries.GetAdvertisement;
using AdvertisingApi.CQRS.Queries.GetAllAdvertisements;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AdvertisingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AdvertisementController : Controller
    {
        private readonly IMediator _mediator;

        public AdvertisementController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(GetAllAdvertisementsResult), 200)]
        public async Task<IActionResult> GetAdvertisements([FromQuery] int pageNumber, int pageSize,
            string sortBy, bool isAscending)
        {
            var result = await _mediator.Send(new GetAllAdvertisementsQuery(pageNumber, pageSize,
                sortBy, isAscending));
            return Ok(result);
        }

        [HttpGet("{title}")]
        [ProducesResponseType(typeof(GetAdvertisementResult), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetAdvertisement(string title)
        {
            var result = await _mediator.Send(new GetAdvertisementQuery(title));
            return result.Existence == true ? Ok(result) : NotFound
                ("Such advertisement does not exist");
        }

        [HttpPost]
        [ProducesResponseType(typeof(CreateAdvertisementResult), 204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> CreateAdvertisement([FromBody] CreateAdvertisementCommand
            command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
