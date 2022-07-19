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

    [HttpGet(Name = nameof(Get))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Get()
    {
        var result = await _todoService.GetTodoItems();
        return Ok(result);
    }

    #endregion
}