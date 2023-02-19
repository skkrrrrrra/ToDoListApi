using ToDoList.Entities;

namespace ToDoList.Repository
{
    public interface IInMemToDoItemsRepository
    {
        void CreateItem(ToDoItem tdi);
        void DeleteItem(Guid id);
        ToDoItem GetItem(Guid id);
        IEnumerable<ToDoItem> GetItems();
        IEnumerable<ToDoItem> GetNotCompleted();
        void UpdateItem(ToDoItem tdi);

    }
}