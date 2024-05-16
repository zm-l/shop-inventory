using KyberlifeInterviewCsharp.Infrastructure.GatewayResponses;

namespace KyberlifeInterviewCsharp.Core.DTO.GatewayResponses;

public class CreateOrUpdateResponse<T>(int id, T? result, bool success, List<Error> errors)
    : BaseGatewayResponse(success, errors)
{
    public int Id { get; set; } = id;
    public T? Result { get; set; } = result;
}