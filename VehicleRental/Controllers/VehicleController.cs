using Microsoft.AspNetCore.Mvc;
using VehicleRental.Models.Contracts;
using VehicleRental.Models.ViewModels.Vehicles;

namespace VehicleRental.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VehicleController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] VehicleModel model, [FromServices] IVehicleService vehicleService)
        {
            var vehicle = await vehicleService.Register(model.Map());
            return Ok(vehicle);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Find([FromRoute] string id, [FromServices] IVehicleService vehicleService)
        {
            var vehicle = await vehicleService.Find(id);
            return Ok(vehicle);
        }

        [HttpPatch("{id}/rent")]
        public async Task<IActionResult> Rent([FromRoute] string id, [FromServices] IVehicleService vehicleService)
        {
            //httpcontext get userId;
            //await vehicleService.Rent(id);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove([FromRoute] string id, [FromServices] IVehicleService vehicleService)
        {
            await vehicleService.Remove(id);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> List([FromServices] IVehicleService vehicleService)
        {
            var (count, vehicles) = await vehicleService.List();
            return Ok(new { count, vehicles });
        }

        [HttpPatch("{id}/give-back")]
        public async Task<IActionResult> GiveBack([FromRoute] string id, [FromServices] IVehicleService vehicleService)
        {
            var vehicle = await vehicleService.Find(id);
            if (vehicle?.UserId == null) return BadRequest();

            await vehicleService.GiveBack(id, vehicle.UserId);
            return Ok();
        }
    }
}
