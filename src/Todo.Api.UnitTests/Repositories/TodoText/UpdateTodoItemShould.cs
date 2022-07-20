using Newtonsoft.Json;
using Todo.Api.Models;
using Todo.Api.Repositories;
using Xunit;

namespace Todo.Api.UnitTests.Repositories.TodoText;

/// <summary>
///     Tests the functionality of the <see cref="TodoTextRepository.UpdateTodoItem" /> method.
/// </summary>
public class UpdateTodoItemShould : TodoTextRepositoryTestsBase
{
    #region Public Methods

    /// <summary>
    ///     Given there is a record with a matching Id, updates the store with the new state.
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task UpdatesTheRecordWithMatchingId()
    {
        //Arrange
        string testFile = Path.Combine(Environment.CurrentDirectory, "testdata.json");
        IEnumerable<TodoItem> items = new List<TodoItem>
                                      { new() { Id = 1, Description = "complete to-do app", Type = TodoType.Pending } };
        string json = JsonConvert.SerializeObject(items);
        await File.WriteAllTextAsync(testFile, json);

        var sut = GetDefaultSystemUnderTest();
        var fakeItem = new TodoItem { Id = 1, Description = "complete to-do app", Type = TodoType.Completed };

        //Act
        var result = await sut.UpdateTodoItem(fakeItem);

        //Assert
        Assert.NotSame(fakeItem, result);
    }

    #endregion
}