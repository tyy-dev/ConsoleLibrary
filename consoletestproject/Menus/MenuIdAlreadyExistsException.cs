namespace consoletestproject.Menus
{
    /// <summary>
    /// Thrown when an menu id for an Menu already exists or when a MenuOption's id already exists in the same menu
    /// </summary>
    /// <param name="message">Extra information regarding the exception</param>
    public class MenuIdAlreadyExistsException(string message) : Exception(message)
    {
    }
}
