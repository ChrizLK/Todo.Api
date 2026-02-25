using System.ComponentModel.DataAnnotations;

namespace Todo.Api.Dto
{
    public record TodoUpdateDto
    {
        [Required, MaxLength(100)]
        public string Title { get; set; }
        public string? Description { get; set; }
        public bool IsCompleted { get; set; }
    }
}
