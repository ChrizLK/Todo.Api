using System.ComponentModel.DataAnnotations;

namespace Todo.Api.Dto
{
    public record TodoCreateDto
    {
        [Required, MaxLength(100)]
        public string Title { get; set; }
        public string? Description { get; set; }
    }
}
