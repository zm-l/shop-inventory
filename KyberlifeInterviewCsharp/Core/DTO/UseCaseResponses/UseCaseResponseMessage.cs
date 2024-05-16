namespace KyberlifeInterviewCsharp.Core.DTO.UseCaseResponses;

/// <summary>
/// Response message for UseCases to transmit data back to the Service layer.
///
/// All UseCases should return a concrete instance of this class.
/// </summary>
public abstract class UseCaseResponseMessage(bool success, List<Error> errors)
{
    public bool Success { get; init; } = success;
    public List<Error> Errors { get; init; } = errors;
}