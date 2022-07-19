
using Todo.Api.Interfaces.Repositories;
using Todo.Api.Models;

namespace Todo.Api.Repositories
{
    /// <inheritdoc />
    public class TodoPostgresRepository : ITodoRepository
    {
        public TodoPostgresRepository()
        {

        }
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

        #endregion
    }
}
