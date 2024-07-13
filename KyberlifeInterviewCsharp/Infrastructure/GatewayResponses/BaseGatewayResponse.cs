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
public abstract class BaseGatewayResponse
{
    public bool Success { get; }
    public List<Error> Errors { get; }

    public BaseGatewayResponse(bool success, List<Error> errors)
    {
        Success = success;
        Errors = errors;
    }
}
