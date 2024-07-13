using System.Text.Json.Serialization;

namespace KyberlifeInterviewCsharp.Core.DTO;

public sealed class Error
{
    public string Description { get; }

    [JsonConstructor]
    public Error(string description)
    {
        Description = description;
    }
}
