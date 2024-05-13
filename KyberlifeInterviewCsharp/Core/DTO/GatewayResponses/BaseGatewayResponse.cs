namespace KyberlifeInterviewCsharp.Core.DTO.GatewayResponses;

public abstract class BaseGatewayResponse(bool success, List<Error> errors)
{
    public bool Success { get; } = success;
    public List<Error> Errors { get; } = errors;
}