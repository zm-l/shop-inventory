using KyberlifeInterviewCsharp.Core.DTO;
using KyberlifeInterviewCsharp.Core.DTO.GatewayResponses;
using KyberlifeInterviewCsharp.Core.Interfaces;
using KyberlifeInterviewCsharp.Domain;
using Microsoft.EntityFrameworkCore;

namespace KyberlifeInterviewCsharp.Infrastructure.Repositories;

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

    public async Task<long> Count()
    {
        return await dbContext.Set<T>().CountAsync();
    }

    public async Task<GetRangeResponse<T>> List()
    {
        try
        {
            var items = await dbContext.Set<T>().ToListAsync();
            return new GetRangeResponse<T>(items, true, []);
        }
        catch (Exception e)
        {
            return new GetRangeResponse<T>([], false, [new Error(e.Message)]);
        }
    }
}