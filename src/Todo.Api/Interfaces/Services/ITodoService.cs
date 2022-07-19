using Todo.Api.Models;

namespace Todo.Api.Interfaces.Services;

/// <summary>
///     Defines a service for fetching and manipulating to-do items.
/// </summary>
public interface ITodoService
{
    #region Public Methods

    /// <summary>
    ///     Retrieve a collection of <see cref="TodoItem" />
    /// </summary>
    /// <returns>An enumerable collection of <see cref="TodoItem" />.</returns>
    Task<IEnumerable<TodoItem>?> GetTodoItems();

    #endregion
}