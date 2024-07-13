using KyberlifeInterviewCsharp.Core.DTO;

namespace KyberlifeInterviewCsharp.Infrastructure.GatewayResponses;

public class CountResponse : BaseGatewayResponse
{
    public long Count { get; set; }

    public CountResponse(long count, bool success, List<Error> errors) : base(success, errors)
    {
        Count = count;
    }
}
