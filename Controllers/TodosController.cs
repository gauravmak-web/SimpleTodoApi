// Controllers/TodosController.cs
using Microsoft.AspNetCore.Mvc;
using SimpleTodoApi.Models;

namespace SimpleTodoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodosController : ControllerBase
    {
        private static List<Todo> todos = new()
        {
            new Todo { Id = 1, Title = "Learn .NET", IsCompleted = false },
            new Todo { Id = 2, Title = "Build API", IsCompleted = true }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Todo>> GetAll() => todos;

        [HttpGet("{id}")]
        public ActionResult<Todo> Get(int id)
        {
            var todo = todos.FirstOrDefault(t => t.Id == id);
            if (todo == null) return NotFound();
            return todo;
        }

        [HttpPost]
        public ActionResult<Todo> Create(Todo newTodo)
        {
            newTodo.Id = todos.Count + 1;
            todos.Add(newTodo);
            return CreatedAtAction(nameof(Get), new { id = newTodo.Id }, newTodo);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Todo updatedTodo)
        {
            var todo = todos.FirstOrDefault(t => t.Id == id);
            if (todo == null) return NotFound();

            todo.Title = updatedTodo.Title;
            todo.IsCompleted = updatedTodo.IsCompleted;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var todo = todos.FirstOrDefault(t => t.Id == id);
            if (todo == null) return NotFound();

            todos.Remove(todo);
            return NoContent();
        }
    }
}
