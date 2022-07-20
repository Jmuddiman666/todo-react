using Todo.Api.Interfaces.Repositories;
using Todo.Api.Models;

namespace Todo.Api.Repositories;

/// <inheritdoc />
public class TodoPostgresRepository : ITodoRepository
{
    #region Constructors

    #endregion

    #region Implementation of ITodoRepository

    /// <inheritdoc />
    public async Task<IEnumerable<TodoItem>?> GetTodoItems()
    {
        //var connStr = "";
        //await using var conn = new NpgsqlConnection(connStr);
        //await conn.OpenAsync();
        //conn.TypeMapper.UseJsonNet();

        ////await using (var cmd = conn.CreateCommand())
        ////{

        ////    cmd.
        ////}
        ///
        throw new NotImplementedException();
    }
    /// <inheritdoc />
    public async Task<TodoItem> CreateTodoItem(TodoItem todoItem)
    {
        throw new NotImplementedException();
    }
    /// <inheritdoc />
    public Task<TodoItem> UpdateTodoItem(TodoItem todoItem)
    {
        throw new NotImplementedException();
    }

    #endregion
}