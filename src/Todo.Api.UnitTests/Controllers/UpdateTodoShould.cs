using Microsoft.AspNetCore.Mvc;
using Todo.Api.Controllers;
using Todo.Api.Models;
using Xunit;

namespace Todo.Api.UnitTests.Controllers;

/// <summary>
///     Tests the functionality of the <see cref="TodoController.Update" /> method.
/// </summary>
public class UpdateTodoShould : TodoControllerTestsBase
{
    #region Public Methods

    /// <summary>
    ///     Given a valid request, should return an <see cref="OkObjectResult" />
    ///     containing the updated to-do item.
    /// </summary>
    [Fact]
    public async Task ReturnOkResultGivenValidRequest()
    {
        //Arrange
        var sut = GetDefaultSystemUnderTest();
        var fakeItem = new TodoItem { Id = 1, Description = "complete to-do app", Type = TodoType.Completed };
        //Act
        object actionResult = await sut.Update(fakeItem);

        //Assert
        Assert.IsAssignableFrom<OkObjectResult>(actionResult);
    }
    /// <summary>
    ///     Should call the dependent service to update the record.
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task CallsUpdateService()
    {
        //Arrange
        var sut = GetDefaultSystemUnderTest();
        var fakeItem = new TodoItem { Id = 1, Description = "complete to-do app", Type = TodoType.Completed };
        _serviceMock.Setup(x => x.UpdateTodoItem(fakeItem)).Verifiable();
        //Act
        await sut.Update(fakeItem);

        //Assert
        _serviceMock.Verify(x => x.UpdateTodoItem(fakeItem));
    }

    #endregion
}