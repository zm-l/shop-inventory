using KyberlifeInterviewCsharp.Core.DTO.GatewayResponses;
using KyberlifeInterviewCsharp.Domain;
using KyberlifeInterviewCsharp.Infrastructure.GatewayResponses;

namespace KyberlifeInterviewCsharp.Infrastructure.Repositories;

/// <summary>
/// ShopItemRepository interface.
///
/// You should add any additional methods you need to interact with the
/// ShopItem entity
/// </summary>
public interface IShopItemRepository
{
    /// <summary>
    /// Returns a list of ShopItems.
    /// </summary>
    Task<GetRangeResponse<ShopItem>> GetAll(bool includeSold);
}