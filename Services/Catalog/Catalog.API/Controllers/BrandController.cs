using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using System.Threading.Tasks;
using Catalog.Application.Queries;
using Catalog.Application.Commands;
using Catalog.Core.Dtos;

namespace Catalog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BrandController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("GetAllBrands")]
        public async Task<IActionResult> GetAllBrands()
        {
            // Implementation for getting brands
            var query = new GetAllBrandsQuery();    
            var brands = await _mediator.Send(query);
            return Ok(brands);
        }

        [HttpGet]
        [Route("GetBrandByID/{id:guid}")]
        public async Task<IActionResult> GetBrandByID([FromRoute] Guid Id)
        {
            var query = new GetBrandByIDQuery(Id);
            var brand = await _mediator.Send(query);
            return Ok(brand);
        }

        [HttpPost]
        [Route("CreateBrand")]
        public async Task<IActionResult> CreateBrand([FromBody] CreateBrandDTO createBrandDTO)
        {
            var command = new CreateBrandCommand(createBrandDTO);
            var brand = await _mediator.Send(command);
            return Ok(brand);
        }

        [HttpPut]
        [Route("UpdateBrand/{id:guid}")]
        public async Task<IActionResult> UpdateBrand([FromRoute] Guid id, [FromBody] UpdateBrandDTO updateBrandDTO)
        {
            var command = new UpdateBrandCommand(id, updateBrandDTO);
            var brand = await _mediator.Send(command);
            return Ok(brand);
        }

        [HttpDelete]
        [Route("DeleteBrand/{id:guid}")]
        public async Task<IActionResult> DeleteBrand([FromRoute] Guid id)
        {
            var command = new DeleteBrandCommand(id);
            await _mediator.Send(command);
            return Ok();
        }
    }
}
