using Todo.Api.Dto;
using Todo.Api.Helpers;

namespace Todo.Api.Services.Interfaces
{
    public interface ITodoService
    {
        Task<Pagination<TodoReadDto>> GetAllAsync(int pageNumber , CancellationToken cancellationToken);
        Task<TodoReadDto?> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task<TodoReadDto> CreateAsync(TodoCreateDto dto, CancellationToken cancellationToken);
        Task<bool> UpdateAsync(int id, TodoUpdateDto dto, CancellationToken cancellationToken);
        Task<bool> DeleteAsync(int id, CancellationToken cancellationToken);
    }
}
