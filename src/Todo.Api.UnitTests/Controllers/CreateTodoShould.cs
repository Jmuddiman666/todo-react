using Microsoft.AspNetCore.Mvc;

using Todo.Api.Controllers;
using Todo.Api.Models;

using Xunit;

namespace Todo.Api.UnitTests.Controllers
{
    /// <summary>
    /// Tests the functionality of the <see cref="TodoController.CreateTodo"/> method.
    /// </summary>
    public class CreateTodoShould : TodoControllerTestsBase
    {
        /// <summary>
        /// Given a valid request should return an OK result.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task ReturnOkResult()
        {
            //Arrange
            var sut = GetDefaultSystemUnderTest();
            var fakeItem = new TodoItem() { Description = "complete to-do app", Type = TodoType.Pending };

            //Act
            var actionResult = await sut.Create(fakeItem);

            //Assert
            Assert.IsAssignableFrom<OkObjectResult>(actionResult);
        }


        /// <summary>
        /// Given a valid request, the item should be returned with an updated Id.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task ReturnUpdatedItemFromService()
        {
            //Arrange
            var fakeItem = new TodoItem() { Description = "complete to-do app", Type = TodoType.Pending };
            var sut = GetDefaultSystemUnderTest();
            _serviceMock.Setup(x => x.CreateTodoItem(fakeItem))
                        .ReturnsAsync(new TodoItem { Id = 1, Description = "complete to-do app", Type = TodoType.Pending });

            //Act
            var actionResult = await sut.Create(fakeItem);

            //Assert
            var objectResult = Assert.IsAssignableFrom<OkObjectResult>(actionResult);
            var result = Assert.IsAssignableFrom<TodoItem>(objectResult.Value);
            Assert.Equal(1, result.Id);
            _serviceMock.Verify(x => x.CreateTodoItem(fakeItem));
        }
    }
}
