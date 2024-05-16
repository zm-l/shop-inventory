using KyberlifeInterviewCsharp.Core.DTO.GatewayResponses;
using KyberlifeInterviewCsharp.Domain;
using KyberlifeInterviewCsharp.Infrastructure.GatewayResponses;

namespace KyberlifeInterviewCsharp.Infrastructure.Repositories;

/// <summary>
/// Generic Repository interface containing some useful methods.
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IRepository<T> where T : BaseEntity
{
    /// <summary>
    /// Creates a new item in the database.
    /// </summary>
    Task<CreateOrUpdateResponse<T>> Create(T item);

    /// <summary>
    /// Updates an existing item in the database based on its id.
    /// </summary>
    Task<CreateOrUpdateResponse<T>> Update(T item);

    /// <summary>
    /// Retrieves an item from the database based on its id.
    /// </summary>
    Task<GetResponse<T>> GetById(int id);

    /// <summary>
    /// Gets the number of items in the database.
    /// </summary>
    Task<CountResponse> Count();
}