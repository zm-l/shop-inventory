namespace KyberlifeInterviewCsharp.Core.DTO.GatewayResponses;

public sealed class GetRangeResponse<T>(List<T> result, bool success, List<Error> errors)
    : BaseGatewayResponse(success, errors)
{
    public List<T> Result { get; set; } = result;
}