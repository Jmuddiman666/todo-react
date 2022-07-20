using Todo.Api.Models;

namespace Todo.Api.Interfaces.Repositories;

/// <summary>
///     Repository for storing and retrieving to-do items.
/// </summary>
public interface ITodoRepository
{
    #region Public Methods

    /// <summary>
    ///     Retrieve a collection of <see cref="TodoItem" /> from the repository.
    /// </summary>
    /// <returns>An enumerable collection of <see cref="TodoItem" />.</returns>
    Task<IEnumerable<TodoItem>?> GetTodoItems();

    /// <summary>
    ///     Create a new to do item in the repository.
    /// </summary>
    /// <param name="todoItem">The to-do item to store.</param>
    /// <returns>The new <see cref="TodoItem" />.</returns>
    Task<TodoItem> CreateTodoItem(TodoItem todoItem);
    /// <summary>
    ///     Updates the repository with the modified To-do record.
    /// </summary>
    /// <param name="todoItem">The updated to-do item.</param>
    /// <returns>The updated record.</returns>
    Task<TodoItem> UpdateTodoItem(TodoItem todoItem);

    #endregion
}