using Todo.Api.Interfaces.Repositories;
using Todo.Api.Interfaces.Services;
using Todo.Api.Models;

namespace Todo.Api.Services;

/// <inheritdoc />
public class TodoService : ITodoService
{
    private readonly ITodoRepository _repository;

    /// <summary>
    /// Default constructor
    /// </summary>
    public TodoService(ITodoRepository repository)
    {
        _repository = repository;
    }
    #region Public Methods

    /// <inheritdoc />
    public async Task<IEnumerable<TodoItem>> GetTodoItems()
    {
        var data = await _repository.GetTodoItems();
        return data ?? new List<TodoItem>();
    }
    /// <inheritdoc />
    public async Task<TodoItem> CreateTodoItem(TodoItem todoItem)
    {
        throw new NotImplementedException();
    }

    #endregion
}