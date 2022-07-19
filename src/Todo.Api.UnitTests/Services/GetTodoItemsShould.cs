using Todo.Api.Models;
using Todo.Api.Services;
using Xunit;

namespace Todo.Api.UnitTests.Services
{
    /// <summary>
    /// Tests the functionality of the <see cref="TodoService.GetTodoItems"/> method.
    /// </summary>
    public class GetTodoItemsShould : TodoServiceTestsBase
    {
        /// <summary>
        /// Given no dependency errors, should return a collection of <see cref="TodoItem"/>.
        /// </summary>
        [Fact]
        public async Task ReturnACollectionOfTodoItems()
        {
            //Arrange
            var sut = GetDefaultSystemUnderTest();

            //Act
            var result = await sut.GetTodoItems();

            //Assert
            Assert.IsAssignableFrom<IEnumerable<TodoItem>>(result);
        }

        /// <summary>
        /// Given the repository is valid, it should be called exactly once returning a valid result.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task CallRepositoryOnce()
        {
            //Arrange
            var fakeTodoItems = new List<TodoItem>()
                                {
                                    new TodoItem { Id=1, Description="complete to-do app", Type=TodoType.Pending}
                                };
            var sut = GetDefaultSystemUnderTest();
            _repositoryMock.Setup(x => x.GetTodoItems())
                           .ReturnsAsync(fakeTodoItems);

            //Act
            var result = await sut.GetTodoItems();

            //Assert
            var collection = Assert.IsAssignableFrom<IEnumerable<TodoItem>>(result);
            Assert.Collection(collection, x => Assert.Equal(1, x.Id));
            _repositoryMock.Verify(x => x.GetTodoItems(), Times.Once);
        }
    }
}

