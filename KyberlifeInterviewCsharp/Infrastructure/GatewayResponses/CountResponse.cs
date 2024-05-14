using KyberlifeInterviewCsharp.Core.DTO;

namespace KyberlifeInterviewCsharp.Infrastructure.GatewayResponses;

public class CountResponse(long count, bool success, List<Error> errors) : BaseGatewayResponse(success, errors)
{
    public long Count { get; set; } = count;
}