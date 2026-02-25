using Microsoft.AspNetCore.Mvc;
using Todo.Api.Dto;
using Todo.Api.Services.Interfaces;

namespace Todo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {

        #region Private Variables
        private readonly ITodoService _service;

        #endregion

        #region Constructor

        public TodoItemsController(ITodoService service)
        {
            _service = service;
        }

        #endregion

        #region Get Endpoints

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken ,int pageNumber = 1)
        {
            var result = await _service.GetAllAsync(pageNumber,cancellationToken);
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id,CancellationToken cancellationToken)
        {
            var item = await _service.GetByIdAsync(id,cancellationToken);

            if (item == null)
            { 
                return NotFound();
            }

            return Ok(item);
        }

        #endregion

        [HttpPost]
        public async Task<IActionResult> Create(TodoCreateDto dto,CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var created = await _service.CreateAsync(dto,cancellationToken);

            return Created();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TodoUpdateDto dto,CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); 
            }

            var updated = await _service.UpdateAsync(id, dto,cancellationToken);

            if (!updated)
            {
                return NotFound(); 
            }

            return Ok("Updated successfully.");
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id,CancellationToken cancellationToken)
        {
            var deleted = await _service.DeleteAsync(id,cancellationToken);

            if (!deleted)
            {
                return NotFound(); 
            }

            return Ok("Deleted successfully.");
        }
    }
}

