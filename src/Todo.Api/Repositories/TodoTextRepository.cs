using Todo.Api.Interfaces.Repositories;
using Todo.Api.Models;

namespace Todo.Api.Repositories
{
    /// <inheritdoc />
    public class TodoTextRepository : ITodoRepository
    {
        private readonly string _filePath;
        public TodoTextRepository()
        {
            _filePath = Path.Combine(Environment.CurrentDirectory, "testdata.json");
        }
        #region Implementation of ITodoRepository

        /// <inheritdoc />
        public async Task<IEnumerable<TodoItem>?> GetTodoItems()
        {
            if (System.IO.File.Exists(_filePath))
            {

                string fileData = await System.IO.File.ReadAllTextAsync(_filePath);
                if (!string.IsNullOrEmpty(fileData))
                {
                    var data = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<TodoItem>>(fileData);
                    if (data != null)
                        return data;
                }
            }

            return new List<TodoItem>();
        }
        /// <inheritdoc />
        public async Task<TodoItem> CreateTodoItem(TodoItem todoItem)
        {
            List<TodoItem> todoItems = new List<TodoItem>();
            if (System.IO.File.Exists(_filePath))
            {
                string fileData = await System.IO.File.ReadAllTextAsync(_filePath);
                if (!string.IsNullOrEmpty(fileData))
                {
                    var data = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<TodoItem>>(fileData);
                    if (data != null)
                    {
                        todoItems = data.ToList();
                    }
                }
            }

            int maxId = todoItems.Any() ? todoItems.Max(x => x.Id) : 0;
            todoItem.Id = maxId + 1;
            todoItems.Add(todoItem);

            string json = Newtonsoft.Json.JsonConvert.SerializeObject(todoItems);
            await File.WriteAllTextAsync(_filePath, json);

            return todoItem;

        }

        #endregion
    }
}
