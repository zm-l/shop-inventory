using KyberlifeInterviewCsharp.Core.DTO.GatewayResponses;
using KyberlifeInterviewCsharp.Domain;
using Microsoft.EntityFrameworkCore;

namespace KyberlifeInterviewCsharp.Infrastructure.Repositories;

/// <summary>
/// Implementation of IShopItemRepository.
///
/// This class contains helpful methods to interact with this entity and the
/// database from the UseCase layer.
///
/// Add any additional methods here if needed.
/// </summary>
public class ShopItemRepository : Repository<ShopItem>, IShopItemRepository
{
    private readonly KyberlifeInterviewDbContext _dbContext;

    public ShopItemRepository(KyberlifeInterviewDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<GetRangeResponse<ShopItem>> GetAll(bool includeSold)
    {
        try
        {
            var shopItems = await _dbContext.ShopItems
                .Where(shopItem => includeSold || !shopItem.IsSold) //Filter out sold items if includeSold==true
                .ToListAsync();
            return new GetRangeResponse<ShopItem>(shopItems, true, []);
        }
        catch (Exception e)
        {
            return new GetRangeResponse<ShopItem>([], false, [new Error(e.Message)]);
        }
    }
}