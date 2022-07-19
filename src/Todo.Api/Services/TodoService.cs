using Todo.Api.Interfaces.Services;
using Todo.Api.Models;

namespace Todo.Api.Services;

/// <inheritdoc />
public class TodoService : ITodoService
{
    #region Public Methods

    /// <inheritdoc />
    public async Task<IEnumerable<TodoItem>> GetTodoItems()
    {
        var data = new List<TodoItem>
                   {
                       new()
                       {
                           Id = 1,
                           Description = "complete to-do app",
                           Type = TodoType.Pending
                       },
                       new()
                       {
                           Id = 2,
                           Description = "complete to-do deployment",
                           Type = TodoType.Completed
                       }
                   };
        return data;
    }

    #endregion
}