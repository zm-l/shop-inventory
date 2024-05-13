using KyberlifeInterviewCsharp.Core.DTO.GatewayResponses;
using KyberlifeInterviewCsharp.Domain;

namespace KyberlifeInterviewCsharp.Core.Interfaces;

public interface IRepository<T> where T : BaseEntity
{
    Task<CreateOrUpdateResponse<T>> Create(T item);
    Task<CreateOrUpdateResponse<T>> Update(T item);
    Task<GetResponse<T>> GetById(int id);
    Task<long> Count();
    Task<GetRangeResponse<T>> List();
}