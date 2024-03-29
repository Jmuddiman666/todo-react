﻿using Todo.Api.Interfaces.Repositories;
using Todo.Api.Interfaces.Services;
using Todo.Api.Models;

namespace Todo.Api.Services;

/// <inheritdoc />
public class TodoService : ITodoService
{
    #region Fields

    private readonly ITodoRepository _repository;

    #endregion

    #region Constructors

    /// <summary>
    ///     Default constructor
    /// </summary>
    public TodoService(ITodoRepository repository)
    {
        _repository = repository;
    }

    #endregion

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
        var newItem = await _repository.CreateTodoItem(todoItem);
        return newItem;
    }
    /// <inheritdoc />
    public async Task<TodoItem> UpdateTodoItem(TodoItem todoItem)
    {
        return await _repository.UpdateTodoItem(todoItem);
    }

    #endregion
}