using AspireApp.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspireApp.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class GenericController<TDto, TEntity> : ControllerBase
        where TEntity : class
        where TDto : class
    {
        protected readonly IService<TDto> _service;

        public GenericController(IService<TDto> service)
        {
            _service = service;
        }

        [HttpGet]
        public virtual async Task<ActionResult<IEnumerable<TDto>>> GetAllAsync()
        {
            var dtos = await _service.GetAllAsync();
            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public virtual async Task<ActionResult<TDto>> GetByIdAsync(string id)
        {
            var dto = await _service.GetByIdAsync(id);
            if (dto == null)
            {
                return NotFound();
            }
            return Ok(dto);
        }

        [HttpPost]
        public virtual async Task<ActionResult<TDto>> AddAsync(TDto dto)
        {
            await _service.AddAsync(dto);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = dto }, dto);
        }

        [HttpPut("{id}")]
        public virtual async Task<IActionResult> UpdateAsync(string id, TDto dto)
        {
            await _service.UpdateAsync(dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> DeleteAsync(string id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
