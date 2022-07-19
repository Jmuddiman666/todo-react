using Todo.Api.Models;

using Xunit;

namespace Todo.Api.UnitTests.Repositories.TodoText
{
    /// <summary>
    /// Tests the functionality of the <see cref="GetTodoItemsShould"/> method.
    /// </summary>
    public class GetTodoItemsShould : TodoTextRepositoryTestsBase
    {
        /// <summary>
        /// Given a json file exists containing a collection, then the collection of <see cref="TodoItem"/> should be deserialized and returned.
        /// </summary>
        [Fact]
        public async Task ShouldRetrieveJsonCollectionFromFileIfExists()
        {
            //Arrange
            var testFile = Path.Combine(Environment.CurrentDirectory, "testdata.json");
            IEnumerable<TodoItem> items = new List<TodoItem>() { new TodoItem { Id = 1, Description = "complete to-do app", Type = TodoType.Pending } };
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(items);
            await File.WriteAllTextAsync(testFile, json);

            var sut = GetDefaultSystemUnderTest();

            //Act
            var result = await sut.GetTodoItems();

            //Assert
            var collection = Assert.IsAssignableFrom<IEnumerable<TodoItem>>(result);
            Assert.Collection(collection, x => Assert.Equal(1, x.Id));
        }
    }
}
