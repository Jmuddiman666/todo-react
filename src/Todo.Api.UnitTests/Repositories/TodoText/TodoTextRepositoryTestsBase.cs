namespace Todo.Api.UnitTests.Repositories.TodoText
{
    /// <summary>
    /// Base class for <see cref="TodoTextRepository"/> related tests.
    /// </summary>
    public abstract class TodoTextRepositoryTestsBase : ITest<Api.Repositories.TodoTextRepository>
    {
        #region Implementation of ITest<out ITodoRepository>

        /// <inheritdoc />
        public Api.Repositories.TodoTextRepository GetDefaultSystemUnderTest()
        {
            var sut = new Api.Repositories.TodoTextRepository();
            return sut;
        }

        #endregion
    }
}
