using Todo.Api.Models;
using Todo.Api.Services;
using Xunit;

namespace Todo.Api.UnitTests.Services;

/// <summary>
///     Tests the functionality of the <see cref="TodoService.UpdateTodoItem" /> method.
/// </summary>
public class UpdateTodoItemShould : TodoServiceTestsBase
{
    #region Public Methods

    /// <summary>
    ///     Given a valid request, the updated <see cref="TodoItem" /> should be returned.
    /// </summary>
    [Fact]
    public async Task ReturnUpdatedItemFromRepository()
    {
        //Arrange
        var sut = GetDefaultSystemUnderTest();
        var fakeItem = new TodoItem { Id = 1, Description = "complete to-do app", Type = TodoType.Completed };
        _repositoryMock.Setup(x => x.UpdateTodoItem(fakeItem))
                       .ReturnsAsync(new TodoItem { Id = 1, Description = "complete to-do app", Type = TodoType.Completed });
        //Act
        var result = await sut.UpdateTodoItem(fakeItem);

        //Assert
        Assert.IsAssignableFrom<TodoItem>(result);
        Assert.NotSame(fakeItem, result);
        _repositoryMock.Verify(x => x.UpdateTodoItem(fakeItem));
    }

    #endregion
}