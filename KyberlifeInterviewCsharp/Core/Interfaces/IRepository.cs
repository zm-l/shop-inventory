using KyberlifeInterviewCsharp.Core.DTO.GatewayResponses;
using KyberlifeInterviewCsharp.Domain;
using KyberlifeInterviewCsharp.Infrastructure.GatewayResponses;

namespace KyberlifeInterviewCsharp.Core.Interfaces;

public interface IRepository<T> where T : BaseEntity
{
    Task<CreateOrUpdateResponse<T>> Create(T item);
    Task<CreateOrUpdateResponse<T>> Update(T item);
    Task<GetResponse<T>> GetById(int id);
    Task<CountResponse> Count();
}