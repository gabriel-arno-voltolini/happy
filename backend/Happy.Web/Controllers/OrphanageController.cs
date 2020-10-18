using Castle.Core.Internal;
using Happy.Application.Interfaces.Services;
using Happy.Application.Models.Orphanage;
using Happy.Web.Interfaces.Controllers.Orphanage;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Happy.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrphanageController : ControllerBase, IOrphanageController
    {
        private readonly IOrphanageService _orphanageService;

        public OrphanageController(IOrphanageService orphanageService)
        {
            _orphanageService = orphanageService;
        }

        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var response = await _orphanageService.Delete(id);

            if (response.Success)
                return Ok();
            else
                return BadRequest(response.Errors);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _orphanageService.GetAll();

            if (response.Data.IsNullOrEmpty())
                return NoContent();

            else if (response.Success)
                return Ok(response.Data);

            else
                return BadRequest(response.Errors);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var response = await _orphanageService.GetById(id);

            if (response.Data.IsNullOrEmpty())
                return NoContent();

            else if (response.Success)
                return Ok(response.Data);

            else
                return BadRequest(response.Errors);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] OrphanageRequestModel requestModel)
        {
            var response = await _orphanageService.Create(requestModel);

            if (response.Success)
                return Ok(response.Data.FirstOrDefault());
            else
                return BadRequest(response.Errors);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] OrphanageRequestModel requestModel)
        {
            var response = await _orphanageService.Update(id, requestModel);

            if (response.Success)
                return Ok();
            else
                return BadRequest(response.Errors);
        }
    }
}