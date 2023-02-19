using Microsoft.AspNetCore.Mvc;
using ToDoList.DTOs;
using ToDoList.Entities;
using ToDoList.Repository;

namespace ToDoList.Controllers
{
    [ApiController]
    [Route("todoitems")]
    public class ToDoItemController : Controller
    {
        private readonly IInMemToDoItemsRepository _repository;
        public ToDoItemController(IInMemToDoItemsRepository repository)
        {
            _repository = repository;
        }
        //GET /items/{id}
        [HttpGet("{id}")]
        public ActionResult<ToDoItem> GetItem(Guid id)
        {
            var item = _repository.GetItem(id);
            if(item is null)
            {
                return NotFound();
            }
            return item;
        }
        //GET /items
        [HttpGet("all")]
        public IEnumerable<ToDoItemDto> GetAllOfItems()
        {
            var items = _repository.GetItems().Select(item => new ToDoItemDto
            {
                Id = item.Id,
                Title = item.Title,
                Description = item.Description,
                isComplete = item.isComplete,
                CreatedDate = item.CreatedDate
            });
            return items;
        }
        [HttpGet("notCompleted")]
        public IEnumerable<ToDoItemDto> GetIsNotCopletedItems()
        {
            var items = _repository.GetNotCompleted().Select(item => new ToDoItemDto
            {
                Id = item.Id,
                Title = item.Title,
                Description = item.Description,
                isComplete = item.isComplete,
                CreatedDate = item.CreatedDate
            });
            return items;
        }
        //POST /items
        [HttpPost]
        public ActionResult CreateItem(CreateToDoItemDto itemDto)
        {
            if (itemDto is null)
            {
                return BadRequest();
            }
            ToDoItem item = new()
            {
                Id = Guid.NewGuid(),
                Title = itemDto.Title,
                Description = itemDto.Description,
                isComplete = false,
                CreatedDate = DateTimeOffset.UtcNow
            };
            _repository.CreateItem(item);
            return Ok();
        }

        //PUT /items/{id}

        [HttpPut("{id}")]
        public ActionResult UpdateItem(Guid id, UpdateToDoItemDto itemDto)
        {
            var existingItem = _repository.GetItem(id);

            if (existingItem == null)
            {
                return NotFound();
            }

            ToDoItem updatedItem = new()
            {
                Id = existingItem.Id,
                Title = existingItem.Title,
                Description = existingItem.Description,
                isComplete = false,
                CreatedDate = existingItem.CreatedDate
            };
            _repository.UpdateItem(updatedItem);

            return Ok();
        }

        //DELETE /items/{id}
        [HttpDelete("{id}")]
        public ActionResult<ToDoItemDto> DeleteItem(Guid id)
        {
            var existingItem = _repository.GetItem(id);

            if(existingItem is null)
            {
                return NotFound();
            }
            
            _repository.DeleteItem(existingItem.Id);
            return Ok();

        }
    }
}
