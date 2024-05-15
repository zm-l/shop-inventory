namespace KyberlifeInterviewCsharp.Service.Requests;

public class CreateOrUpdateShopItemRequest
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public bool IsSold { get; set; }
}