using KyberlifeInterviewCsharp.Infrastructure.GatewayResponses;

namespace KyberlifeInterviewCsharp.Core.DTO.GatewayResponses;

public class CreateOrUpdateResponse<T> : BaseGatewayResponse
{
    public int Id { get; set; }
    public T? Result { get; set; }

    public CreateOrUpdateResponse(int id, T? result, bool success, List<Error> errors) : base(success, errors)
    {
        Id = id;
        Result = result;
    }
}
