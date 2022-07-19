using Microsoft.AspNetCore.Mvc;
using Todo.Api.Controllers;
using Todo.Api.Interfaces.Services;
using Todo.Api.Models;
using Xunit;

namespace Todo.Api.UnitTests.Controllers;

/// <summary>
///     Tests the functionality of the <see cref="TodoController" />
/// </summary>
public class GetTodosShould : TodoControllerTestsBase
{
    #region Public Methods

    /// <summary>
    ///     Given the collection of to-do items is empty, then an empty collection of <see cref="TodoItem" /> should be
    ///     returned
    ///     wrapped in an <seealso cref="OkObjectResult" />
    /// </summary>
    [Fact]
    public async Task ReturnsAnEmptyCollectionOfTodoItems()
    {
        //Arrange
        var sut = GetDefaultSystemUnderTest();
        _serviceMock.Setup(x => x.GetTodoItems()).ReturnsAsync(new List<TodoItem>());
        //Act
        var actionResult = await sut.Get();

        //Assert
        var objectResult = Assert.IsAssignableFrom<OkObjectResult>(actionResult);
        var collection = Assert.IsAssignableFrom<IEnumerable<TodoItem>>(objectResult.Value);
        Assert.Empty(collection);
    }

    /// <summary>
    ///     Given a to-do items exist, returns the collection from the <see cref="ITodoService" />
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task RetrievesACollectionOfTodoItemsFromService()
    {
        //Arrange
        var sut = GetDefaultSystemUnderTest();
        var mockItems = new List<TodoItem>
                        {
                            new() { Id = 1, Description = "complete to-do app", Type = TodoType.Pending }
                        };
        _serviceMock.Setup(x => x.GetTodoItems()).ReturnsAsync(mockItems);
        //Act
        var actionResult = await sut.Get();

        //Assert
        var objectResult = Assert.IsAssignableFrom<OkObjectResult>(actionResult);
        var collection = Assert.IsAssignableFrom<IList<TodoItem>>(objectResult.Value);
        Assert.Collection(collection,
                          item =>
                          {
                              Assert.Equal(1, item.Id);
                              Assert.Equal("complete to-do app", item.Description);
                              Assert.Equal(TodoType.Pending, item.Type);
                          });
    }

    #endregion
}