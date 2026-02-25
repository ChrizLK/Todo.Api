using Microsoft.EntityFrameworkCore;
using Todo.Api.Data;
using Todo.Api.Dto;
using Todo.Api.Helpers;
using Todo.Api.Services.Interfaces;

namespace Todo.Api.Services
{
    public class TodoService : ITodoService
    {
        #region Private Variables

        private readonly AppDbContext _context;
        private const int PageSize = 10;

        #endregion

        #region Contsructor

        public TodoService(AppDbContext context)
        {
            _context = context;
        }

        #endregion

        #region Get

        public async Task<Pagination<TodoReadDto>> GetAllAsync(int pageNumber,CancellationToken cancellationToken)
        {
            var query = _context.Todos.AsNoTracking();

            var totalCount = await query.CountAsync();

            var items = await query
                .OrderByDescending(x => x.CreatedAt)
                .Skip((pageNumber - 1) * PageSize)
                .Take(PageSize)
                .Select(x => new TodoReadDto
                {
                    id = x.id,
                    Title = x.Title,
                    Description = x.Description,
                    IsCompleted = x.IsCompleted,
                    CreatedAt = x.CreatedAt
                })
                .ToListAsync(cancellationToken);

            return new Pagination<TodoReadDto>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = PageSize
            };
        }

        public async Task<TodoReadDto?> GetByIdAsync(int id,CancellationToken cancellationToken)
        {
            return await _context.Todos
                .Where(x => x.id == id)
                .Select(x => new TodoReadDto
                {
                    id = x.id,
                    Title = x.Title,
                    Description = x.Description,
                    IsCompleted = x.IsCompleted,
                    CreatedAt = x.CreatedAt
                })
                .FirstOrDefaultAsync(cancellationToken);
        }

        #endregion

        public async Task<TodoReadDto> CreateAsync(TodoCreateDto dto,CancellationToken cancellationToken)
        {
            var entity = new Models.TodoItem
            {
                Title = dto.Title,
                Description = dto.Description
            };

            await  _context.Todos.AddAsync(entity,cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return new TodoReadDto
            {
                id = entity.id,
                Title = entity.Title,
                Description = entity.Description,
                IsCompleted = entity.IsCompleted,
                CreatedAt = entity.CreatedAt
            };
        }

        public async Task<bool> UpdateAsync(int id, TodoUpdateDto dto,CancellationToken cancellationToken)
        {
            var entity = await _context.Todos.FindAsync(id,cancellationToken);
            if (entity == null) return false;

            entity.Title = dto.Title;
            entity.Description = dto.Description;
            entity.IsCompleted = dto.IsCompleted;

            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<bool> DeleteAsync(int id,CancellationToken cancellationToken)
        {
            var entity = await _context.Todos.FindAsync(id,cancellationToken);
            if (entity == null) return false;

            _context.Todos.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

    }
}
