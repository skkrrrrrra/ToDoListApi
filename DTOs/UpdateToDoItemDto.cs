namespace ToDoList.DTOs
{
    public class UpdateToDoItemDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool isComplete { get; set; }
    }
}
