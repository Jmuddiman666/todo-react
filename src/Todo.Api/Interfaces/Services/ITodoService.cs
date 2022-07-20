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
    Task<IEnumerable<TodoItem>> GetTodoItems();
    /// <summary>
    ///     Create a new to-do item and return the updated object.
    /// </summary>
    /// <param name="todoItem">The to-do item to be created.</param>
    /// <returns>The new To do item.</returns>
    Task<TodoItem> CreateTodoItem(TodoItem todoItem);
    /// <summary>
    ///     Update stores to reflect the modified to-do item.
    /// </summary>
    /// <param name="todoItem">The updated to-do item.</param>
    /// <returns>The updated <see cref="TodoItem" /> reference.</returns>
    Task<TodoItem> UpdateTodoItem(TodoItem todoItem);

    #endregion
}