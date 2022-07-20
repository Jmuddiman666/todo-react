using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Api.Models;
using Todo.Api.Services;
using Xunit;

namespace Todo.Api.UnitTests.Services
{
    /// <summary>
    /// Tests the functionality of the <see cref="TodoService.CreateTodoItem(Models.TodoItem)"/> method.
    /// </summary>
    public class CreateTodoItemShould:TodoServiceTestsBase
    {
        [Fact]
        public async Task ReturnTodoItemFromRepository()
        {
            //Arrange
            var sut = GetDefaultSystemUnderTest();
            var fakeItem = new TodoItem() { Id = 0, Description = "complete to-do app", Type = TodoType.Pending };
            _repositoryMock.Setup(x => x.CreateTodoItem(fakeItem))
                           .ReturnsAsync(new TodoItem() { Id = 1, Description = "complete to-do app", Type = TodoType.Pending });

            //Act
            var result = await sut.CreateTodoItem(fakeItem);

            //Assert
            Assert.IsAssignableFrom<TodoItem>(result);
            Assert.Equal(1, result.Id);
            _repositoryMock.Verify(x => x.CreateTodoItem(fakeItem));
        }

    }
}
