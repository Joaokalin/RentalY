using Microsoft.AspNetCore.Mvc;
using VehicleRental.Models.Contracts;
using VehicleRental.Models.Entities;
using VehicleRental.Models.ViewModels.Establishments;

namespace VehicleRental.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EstablishmentController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Register([FromBody]EstablishmentModel model, [FromServices] IEstablishmentService establishmentService)
        {
            var establishment = await establishmentService.Register(model.Map());

            return Ok(establishment);
        }

        [HttpGet]
        public async Task<IActionResult> List([FromServices] IEstablishmentService establishmentService)
        {
            var establishments = await establishmentService.List();

            return Ok(establishments);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Find([FromRoute] string id, [FromServices] IEstablishmentService establishmentService)
        {
            var establishemnt = await establishmentService.Find(id);

            return Ok(establishemnt);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody]Establishment model, [FromServices] IEstablishmentService establishmentService)
        {
            var establishemnt = await establishmentService.Update(model);

            return Ok(establishemnt);
        }
    }
}
