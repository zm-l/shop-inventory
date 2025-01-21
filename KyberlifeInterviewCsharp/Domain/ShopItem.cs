namespace KyberlifeInterviewCsharp.Domain;

/// <summary>
/// The ShopItem entity representing an item in the shop.
///
/// You should not need to modify this class.
/// </summary>
public class ShopItem : BaseEntity
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public bool IsSold { get; set; }

    public ShopItem(string name, decimal price, bool isSold)
    {
        Name = name;
        Price = price;
        IsSold = isSold;
    }

    public ShopItem(int id, string name, decimal price, bool isSold)
    {
        Id = id;
        Name = name;
        Price = price;
        IsSold = isSold;
    }

    public override string ToString()
    {
        var status = IsSold ? "SOLD" : "UNSOLD";
        return $"[{status}] {Name} - ${Price}";
    }
}
