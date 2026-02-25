using System;
using System.ComponentModel.DataAnnotations;

namespace Todo.Api.Models
{
    public sealed class TodoItem
    {
        [Key]
        public int id { get; set; }
        [Required,MaxLength(100)]
        public string Title { get; set; }
        public string? Description { get; set; } = string.Empty;
        public bool IsCompleted { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
