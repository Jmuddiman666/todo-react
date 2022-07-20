using Microsoft.AspNetCore.Mvc;
using Todo.Api.Interfaces.Services;
using Todo.Api.Models;

namespace Todo.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TodoController : ControllerBase
{
    #region Fields

    private readonly ILogger<TodoController> _logger;
    private readonly ITodoService _todoService;

    #endregion

    #region Constructors

    public TodoController(ILogger<TodoController> logger, ITodoService todoService)
    {
        _logger = logger;
        _todoService = todoService;
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Get a list of all to do items.
    /// </summary>
    /// <returns></returns>
    [HttpGet(Name = nameof(Get))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Get()
    {
        var result = await _todoService.GetTodoItems();
        return Ok(result);
    }

    /// <summary>
    /// Create a new to-do item. Returns an <see cref="OkObjectResult"/>
    /// </summary>
    /// <param name="todoItem"></param>
    /// <returns></returns>
    [HttpPost(Name =nameof(Create))]
    [ProducesResponseType(typeof(TodoItem), StatusCodes.Status200OK)]
    public async Task<IActionResult> Create(TodoItem todoItem)
    {
        var newItem = await _todoService.CreateTodoItem(todoItem);
        return Ok(newItem);
    }

    #endregion
}