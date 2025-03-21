using Application.DTOs;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeServices _employeeServices;

        public EmployeeController(IEmployeeServices employeeServices)
        {
            _employeeServices = employeeServices;
        }

        [HttpPost]
        [Route("Create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateAsync([FromBody] EmployeeRequest employeeRequest)
        {
            var response = await _employeeServices.CreateAsync(employeeRequest);
            return Ok(response);
        }

        [HttpGet]
        [Route("FindByDocument/{Document}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> FindByDocumentAsync(string Document)
        {
            var response = await _employeeServices.FindByEmployeeDocument(Document);
            return Ok(response);
        }
    }
}
