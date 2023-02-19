using System.ComponentModel.DataAnnotations;

namespace ToDoList.DTOs
{
    public class CreateToDoItemDto
    {
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public bool isComplete { get; set; }
        public DateTimeOffset CreatedDate { get; set; }

    }
}
