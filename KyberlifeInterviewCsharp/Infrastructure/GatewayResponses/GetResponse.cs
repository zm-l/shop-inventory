using KyberlifeInterviewCsharp.Infrastructure.GatewayResponses;

namespace KyberlifeInterviewCsharp.Core.DTO.GatewayResponses;

public sealed class GetResponse<T> : BaseGatewayResponse
{
    public int Id { get; set; }
    public T? Result { get; set; }

    public GetResponse(int id, T? result, bool success, List<Error> errors) : base(success, errors)
    {
        Id = id;
        Result = result;
    }
}
