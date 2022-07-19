using Todo.Api.Controllers;
using Todo.Api.Interfaces.Services;

namespace Todo.Api.UnitTests.Controllers;

/// <summary>
///     Base class for <see cref="TodoController" /> related tests.
/// </summary>
public abstract class TodoControllerTestsBase : ITest<TodoController>
{
    #region Fields

    protected readonly Mock<ILogger<TodoController>> _loggerMock;
    protected readonly Mock<ITodoService> _serviceMock;

    #endregion

    #region Constructors

    /// <summary>
    ///     Default constructor
    ///     Sets up mocks.
    /// </summary>
    protected TodoControllerTestsBase()
    {
        _loggerMock = new Mock<ILogger<TodoController>>();
        _serviceMock = new Mock<ITodoService>();
    }

    #endregion

    #region Public Methods

    #region Implementation of ITestBase<TodoController>

    /// <inheritdoc />
    public TodoController GetDefaultSystemUnderTest()
    {
        var sut = new TodoController(_loggerMock.Object, _serviceMock.Object);
        return sut;
    }

    #endregion

    #endregion
}