// Models/Todo.cs
namespace SimpleTodoApi.Models
{
    public class Todo
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public bool IsCompleted { get; set; }
    }
}
