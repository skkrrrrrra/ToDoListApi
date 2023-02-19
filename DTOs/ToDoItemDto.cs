namespace ToDoList.DTOs
{
    public class ToDoItemDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool isComplete { get; set; }
        public DateTimeOffset CreatedDate { get; set; }

    }
}
