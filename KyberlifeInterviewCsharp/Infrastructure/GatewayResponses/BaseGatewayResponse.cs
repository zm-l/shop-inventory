using KyberlifeInterviewCsharp.Core.DTO;

namespace KyberlifeInterviewCsharp.Infrastructure.GatewayResponses;

/// <summary>
/// The base class for Gateway Responses, for transmitting data back to the UseCase layer.
///
/// Every repository method should return a concrete instance of this class back
/// to the UseCases.
///
/// You should not need to modify this class.
/// </summary>
public abstract class BaseGatewayResponse(bool success, List<Error> errors)
{
    public bool Success { get; } = success;
    public List<Error> Errors { get; } = errors;
}