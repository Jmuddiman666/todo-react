using Newtonsoft.Json;
using Todo.Api.Interfaces.Repositories;
using Todo.Api.Models;

namespace Todo.Api.Repositories;

/// <inheritdoc />
public class TodoTextRepository : ITodoRepository
{
    #region Fields

    private readonly string _filePath;

    #endregion

    #region Constructors

    public TodoTextRepository()
    {
        _filePath = Path.Combine(Environment.CurrentDirectory, "testdata.json");
    }

    #endregion

    #region Implementation of ITodoRepository

    /// <inheritdoc />
    public async Task<IEnumerable<TodoItem>?> GetTodoItems()
    {
        if (File.Exists(_filePath))
        {
            string fileData = await File.ReadAllTextAsync(_filePath);
            if (!string.IsNullOrEmpty(fileData))
            {
                var data = JsonConvert.DeserializeObject<IEnumerable<TodoItem>>(fileData);
                if (data != null)
                    return data;
            }
        }

        return new List<TodoItem>();
    }
    /// <inheritdoc />
    public async Task<TodoItem> CreateTodoItem(TodoItem todoItem)
    {
        var todoItems = new List<TodoItem>();
        if (File.Exists(_filePath))
        {
            string fileData = await File.ReadAllTextAsync(_filePath);
            if (!string.IsNullOrEmpty(fileData))
            {
                var data = JsonConvert.DeserializeObject<IEnumerable<TodoItem>>(fileData);
                if (data != null) todoItems = data.ToList();
            }
        }

        int maxId = todoItems.Any() ? todoItems.Max(x => x.Id) : 0;
        todoItem.Id = maxId + 1;
        todoItems.Add(todoItem);

        string json = JsonConvert.SerializeObject(todoItems);
        await File.WriteAllTextAsync(_filePath, json);

        return todoItem;
    }
    /// <inheritdoc />
    public async Task<TodoItem> UpdateTodoItem(TodoItem todoItem)
    {
        var todoItems = new List<TodoItem>();
        if (File.Exists(_filePath))
        {
            string fileData = await File.ReadAllTextAsync(_filePath);
            if (!string.IsNullOrEmpty(fileData))
            {
                var data = JsonConvert.DeserializeObject<IEnumerable<TodoItem>>(fileData);
                if (data != null) todoItems = data.ToList();
            }
        }

        var existingItem = todoItems.FirstOrDefault(x => x.Id == todoItem.Id);
        if (existingItem != null)
        {
            existingItem.Type = todoItem.Type;

            string json = JsonConvert.SerializeObject(todoItems);
            await File.WriteAllTextAsync(_filePath, json);
            return existingItem;
        }

        return todoItem; //Should throw an exception if not found.
    }

    #endregion
}