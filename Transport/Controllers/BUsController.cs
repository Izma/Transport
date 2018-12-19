using Core;
using Microsoft.AspNetCore.Mvc;
using Entities;
using System.Threading.Tasks;

namespace Transport.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusController : ControllerBase
    {
        private readonly IBus bus;

        public BusController(IBus busCore)
        {
            bus = busCore;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BusModel model)
        {
            var rowsAffected = await bus.SaveBus(model).ConfigureAwait(false);
            if (rowsAffected > 0)
                return StatusCode(200);
            return StatusCode(500);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var list = await bus.GetBuses().ConfigureAwait(false);
            if (list != null)
                return Ok(list);
            return StatusCode(500);
        }
    }
}