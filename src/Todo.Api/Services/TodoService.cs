using Todo.Api.Interfaces.Services;
using Todo.Api.Models;

namespace Todo.Api.Services
{
    /// <inheritdoc />
    public class TodoService : ITodoService
    {
        /// <inheritdoc />
        public Task<IEnumerable<TodoItem>> GetTodoItems()
        {
            throw new NotImplementedException();
        }
    }
}
