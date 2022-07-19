using Todo.Api.Interfaces.Repositories;
using Todo.Api.Services;

namespace Todo.Api.UnitTests.Services
{
    /// <summary>
    /// Base class for <see cref="TodoService"/> related tests.
    /// </summary>
    public abstract class TodoServiceTestsBase : ITest<TodoService>
    {
        protected readonly Mock<ITodoRepository> _repositoryMock;

        protected TodoServiceTestsBase()
        {
            _repositoryMock = new Mock<ITodoRepository>();
        }
        #region Implementation of ITestBase<TodoService>

        /// <inheritdoc />
        public TodoService GetDefaultSystemUnderTest()
        {
            var sut = new TodoService(_repositoryMock.Object);
            return sut;
        }

        #endregion
    }
}
