using System.ComponentModel.DataAnnotations;

namespace ToDoList.Entities
{
    public class ToDoItem
    {
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public bool isComplete { get; set; }
        public DateTimeOffset CreatedDate { get; set; }

    }
}
