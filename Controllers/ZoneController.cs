using Application.DTOs;
using Application.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ZoneController : ControllerBase
    {
        private readonly IZoneServices _zoneServices;
        public ZoneController(IZoneServices zoneServices)
        {
            _zoneServices = zoneServices;
        }
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateAsync([FromBody] ZoneRequest zone)
        {
            var zoneCreated = await _zoneServices.CreateAsync(zone);
            return Ok(zoneCreated);
        }
    }
}
