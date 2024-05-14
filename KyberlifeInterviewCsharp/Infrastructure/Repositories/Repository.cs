using KyberlifeInterviewCsharp.Core.DTO;
using KyberlifeInterviewCsharp.Core.DTO.GatewayResponses;
using KyberlifeInterviewCsharp.Core.Interfaces;
using KyberlifeInterviewCsharp.Domain;
using KyberlifeInterviewCsharp.Infrastructure.GatewayResponses;
using Microsoft.EntityFrameworkCore;

namespace KyberlifeInterviewCsharp.Infrastructure.Repositories;

/// <summary>
/// Generic implementation of IRepository.
/// </summary>
public class Repository<T>(DbContext dbContext) : IRepository<T>
    where T : BaseEntity
{
    public async Task<CreateOrUpdateResponse<T>> Create(T item)
    {
        try
        {
            var addResult = await dbContext.Set<T>().AddAsync(item);
            await dbContext.SaveChangesAsync();
            return new CreateOrUpdateResponse<T>(addResult.Entity.Id, addResult.Entity, true, []);
        }
        catch (Exception e)
        {
            return new CreateOrUpdateResponse<T>(-1, null, false, [new Error(e.Message)]);
        }
    }

    public async Task<CreateOrUpdateResponse<T>> Update(T item)
    {
        try
        {
            var updateResult = dbContext.Set<T>().Update(item);
            await dbContext.SaveChangesAsync();
            return new CreateOrUpdateResponse<T>(updateResult.Entity.Id, item, true, []);
        }
        catch (Exception e)
        {
            return new CreateOrUpdateResponse<T>(-1, null, false, [new Error(e.Message)]);
        }
    }

    public async Task<GetResponse<T>> GetById(int id)
    {
        try
        {
            var findResult = await dbContext.Set<T>().FindAsync(id);
            var isSuccess = findResult != null;
            return new GetResponse<T>(-1, findResult, isSuccess, isSuccess ? [] : [new Error($"Item with id {id} not found.")]);
        }
        catch (Exception e)
        {
            return new GetResponse<T>(-1, null, false, [new Error(e.Message)]);
        }
    }

    public async Task<CountResponse> Count()
    {
        try
        {
            var count = await dbContext.Set<T>().CountAsync();
            return new CountResponse(count, true, []);
        }
        catch (Exception e)
        {
            return new CountResponse(-1, false, [new Error(e.Message)]);
        }
    }
}