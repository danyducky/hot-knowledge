namespace Inspirer.Mvvm.ViewModels;

/// <summary>
/// Indicates whether object has parameters.
/// </summary>
/// <typeparam name="TParameters">View model parameters type.</typeparam>
public interface IWithParameters<TParameters>
{
    /// <summary>
    /// An instance of <see cref="TParameters"/>.
    /// </summary>
    TParameters Parameters { get; set; }
}
