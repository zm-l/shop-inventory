using KyberlifeInterviewCsharp.Domain;

namespace KyberlifeInterviewCsharp.Core.DTO.UseCaseResponses;

public class GetAllShopItemsResponse(List<ShopItem> shopItems, bool success, List<Error> errors)
    : UseCaseResponseMessage(success, errors)
{
    public List<ShopItem> ShopItems { get; } = shopItems;
}