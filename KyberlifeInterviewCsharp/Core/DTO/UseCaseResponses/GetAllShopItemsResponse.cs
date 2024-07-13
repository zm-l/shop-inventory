using KyberlifeInterviewCsharp.Domain;

namespace KyberlifeInterviewCsharp.Core.DTO.UseCaseResponses;

public class GetAllShopItemsResponse : UseCaseResponseMessage
{
    public List<ShopItem> ShopItems { get; }

    public GetAllShopItemsResponse(List<ShopItem> shopItems, bool success, List<Error> errors) : base(success, errors)
    {
        ShopItems = shopItems;
    }
}
