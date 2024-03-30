using System.Collections;

namespace Inspirer.Application.Exceptions;

/// <summary>
/// Application validation exception.
/// </summary>
public class ValidationException : Exception
{
    private readonly Dictionary<string, object> errors = new();

    /// <inheritdoc />
    public override IDictionary Data => errors;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="message">Validation message.</param>
    public ValidationException(string message)
        : base(message)
    {
    }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="errors">Errors dictionary.</param>
    public ValidationException(IDictionary<string, IDictionary> errors)
    {
        ArgumentNullException.ThrowIfNull(errors, nameof(errors));

        AddErrors(errors);
    }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="errors">Errors dictionary.</param>
    public ValidationException(IDictionary<string, string> errors)
    {
        ArgumentNullException.ThrowIfNull(errors, nameof(errors));

        AddErrors(errors);
    }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="title">Exception title.</param>
    /// <param name="message">Exception message.</param>
    public ValidationException(string title, string message)
    {
        ArgumentNullException.ThrowIfNull(message, nameof(message));

        AddError(title, value: message);
    }

    private void AddErrors<TValue>(IDictionary<string, TValue> dict)
        where TValue : class
    {
        foreach (var error in dict)
        {
            AddError(title: error.Key, error.Value);
        }
    }

    private void AddError<TValue>(string title, TValue value)
        where TValue : class
    {
        errors.Add(title, value);
    }
}
