namespace Todo.Api.UnitTests;

/// <summary>
///     Generic interface for tests to retrieve system under test consistently.
/// </summary>
internal interface ITest<out T>
{
    #region Public Methods

    /// <summary>
    ///     Retrieve the default system under test implementation
    /// </summary>
    /// <returns>An instance of the system under test <typeparamref name="T" /></returns>
    T GetDefaultSystemUnderTest();

    #endregion
}