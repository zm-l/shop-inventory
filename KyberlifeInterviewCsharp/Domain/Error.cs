using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace KyberlifeInterviewCsharp.Domain;

/// <summary>
/// A generic Error class.
///
/// You should not need to modify this class.
/// </summary>
public sealed class Error
{
    public string Description { get; }

    [JsonConstructor]
    public Error(string description)
    {
        Description = description;
    }
}
