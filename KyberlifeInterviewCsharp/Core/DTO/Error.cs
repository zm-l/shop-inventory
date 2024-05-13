using System.Text.Json.Serialization;

namespace KyberlifeInterviewCsharp.Core.DTO;

[method: JsonConstructor]
public sealed class Error(string description)
{
    public string Description { get; } = description;
}