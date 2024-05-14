using System.Text.Json.Serialization;

namespace KyberlifeInterviewCsharp.Core.DTO;

/// <summary>
/// Generic error response. Used by both UseCases and Repositories.
/// </summary>
[method: JsonConstructor]
public sealed class Error(string description)
{
    public string Description { get; } = description;
}