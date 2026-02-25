using System.ComponentModel.DataAnnotations;

namespace Todo.Api.Dto
{
    public record TodoReadDto
    {
        public int id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; } = string.Empty;
        public bool IsCompleted { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
