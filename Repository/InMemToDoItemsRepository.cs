using ToDoList.Entities;

namespace ToDoList.Repository
{
    public class InMemToDoItemsRepository : IInMemToDoItemsRepository
    {
        public List<ToDoItem> items = new()
        {
            new ToDoItem(){ 
                Id = Guid.NewGuid(),
                Title = "Throw out the trash",
                Description = "Mom said: throw out the garbage, because today we will have guests.",
                isComplete = false,
                CreatedDate = DateTimeOffset.UtcNow
            },
            new ToDoItem(){
                Id = Guid.NewGuid(),
                Title = "To wash the dishes",
                Description = "Grandma asked me to come to her house today and help wash the dishes.",
                isComplete = false,
                CreatedDate = DateTimeOffset.UtcNow
            },
            new ToDoItem(){
                Id = Guid.NewGuid(),
                Title = "To prepare for an exam",
                Description = "Mom said: throw out the garbage, because today we will have guests.",
                isComplete = true,
                CreatedDate = DateTimeOffset.UtcNow
            }
        };

        public ToDoItem GetItem(Guid id) => items.FirstOrDefault(tit => tit.Id == id);
        public IEnumerable<ToDoItem> GetItems() => items;
        public void CreateItem(ToDoItem tdi) => items.Add(tdi);
        public void UpdateItem(ToDoItem tdi)
        {
            var index = items.FindIndex(i => i.Id == tdi.Id);
            items[index] = tdi;
        }
        public void DeleteItem(Guid id)
        {
            var index = items.FindIndex(tdi => tdi.Id == id);
            items.RemoveAt(index);
        }

        public IEnumerable<ToDoItem> GetNotCompleted()
        {
            var notCompleted = from item in items
                               where item.isComplete is false
                               select item;
            return notCompleted;
        }
    }
}
