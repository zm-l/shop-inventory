using KyberlifeInterviewCsharp.Infrastructure.GatewayResponses;

namespace KyberlifeInterviewCsharp.Core.DTO.GatewayResponses;

public sealed class GetRangeResponse<T> : BaseGatewayResponse
{
    public List<T> Result { get; set; }

    public GetRangeResponse(List<T> result, bool success, List<Error> errors) : base(success, errors)
    {
        Result = result;
    }
}
