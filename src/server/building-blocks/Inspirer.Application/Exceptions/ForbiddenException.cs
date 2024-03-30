namespace Inspirer.Application.Exceptions;

/// <summary>
/// Forbidden exception.
/// </summary>
public class ForbiddenException : Exception
{
    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="message">Exception message.</param>
    public ForbiddenException(string message) : base(message)
    {
    }
}
