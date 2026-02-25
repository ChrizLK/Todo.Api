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
        public async Task<IActionResult> GetAll(int pageNumber = 1)
        {
            var result = await _service.GetAllAsync(pageNumber);
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var item = await _service.GetByIdAsync(id);

            if (item == null)
            { 
                return NotFound();
            }

            return Ok(item);
        }

        #endregion

        [HttpPost]
        public async Task<IActionResult> Create(TodoCreateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var created = await _service.CreateAsync(dto);

            return Created();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TodoUpdateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); 
            }

            var updated = await _service.UpdateAsync(id, dto);

            if (!updated)
            {
                return NotFound(); 
            }

            return Ok("Updated successfully.");
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);

            if (!deleted)
            {
                return NotFound(); 
            }

            return Ok("Deleted successfully.");
        }
    }
}

