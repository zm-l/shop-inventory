using KyberlifeInterviewCsharp.Core.DTO.GatewayResponses;
using KyberlifeInterviewCsharp.Domain;
using KyberlifeInterviewCsharp.Infrastructure.GatewayResponses;

namespace KyberlifeInterviewCsharp.Core.Interfaces;

/// <summary>
/// ShopItemRepository interface.
///
/// You may add more methods to this interface if needed.
/// </summary>
public interface IShopItemRepository
{
    /// <summary>
    /// Returns a list of ShopItems.
    /// </summary>
    Task<GetRangeResponse<ShopItem>> GetAll(bool includeSold);

    /// <summary>
    /// Returns the number of ShopItems in total.
    /// </summary>
    Task<CountResponse> Count();
}