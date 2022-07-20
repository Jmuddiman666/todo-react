using Todo.Api.Models;
using Todo.Api.Repositories;

using Xunit;

namespace Todo.Api.UnitTests.Repositories.TodoText
{
    /// <summary>
    /// Tests the functionality of the <see cref="TodoTextRepository.CreateTodoItem(Models.TodoItem)"/> method.
    /// </summary>
    public class CreateTodoItemShould : TodoTextRepositoryTestsBase
    {

        /// <summary>
        /// Given the repository is cleared, each subsequent insertion should increment the Id by 1.
        /// </summary>
        /// <param name="expectedId">The expected Id.</param>
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public async Task IncrementIdForEachItem(int expectedId)
        {
            //Arrange
            var sut = GetDefaultSystemUnderTest();
            if (expectedId <= 1)
            {
                var testFile = Path.Combine(Environment.CurrentDirectory, "testdata.json");
                System.IO.File.Delete(testFile);
            }

            var fakeItem = new TodoItem() { Id = 0, Description = $"test item {expectedId}", Type = TodoType.Pending };
            //Act
            var result = await sut.CreateTodoItem(fakeItem);

            //Assert
            Assert.Equal(expectedId, result.Id);
        }
    }
}
