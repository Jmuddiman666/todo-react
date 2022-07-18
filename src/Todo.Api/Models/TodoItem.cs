namespace Todo.Api.Models;

/// <summary>
///     Defines a basic to do item.
/// </summary>
public class TodoItem
{
    #region Properties

    /// <summary>
    ///     Gets/sets the to do item description.
    /// </summary>
    public string Description { get; set; } = "";

    /// <summary>
    ///     Gets/sets the unique identifier for the item.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    ///     Gets/sets type of the item.
    /// </summary>
    /// <remarks>
    ///     Pending = 0
    ///     Completed = 1
    /// </remarks>
    public TodoType Type { get; set; }

    #endregion
}