using Todo.Api.Dto;
using Todo.Api.Helpers;

namespace Todo.Api.Services.Interfaces
{
    public interface ITodoService
    {
        Task<Pagination<TodoReadDto>> GetAllAsync(int pageNumber);
        Task<TodoReadDto?> GetByIdAsync(int id);
        Task<TodoReadDto> CreateAsync(TodoCreateDto dto);
        Task<bool> UpdateAsync(int id, TodoUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
