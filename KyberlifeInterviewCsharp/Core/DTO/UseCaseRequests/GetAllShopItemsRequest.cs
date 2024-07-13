namespace KyberlifeInterviewCsharp.Core.DTO.UseCaseRequests;

/// <summary>
/// Request object for getting all shop items.
///
/// This object should be created by the Service layer, and passed to the UseCase layer.
/// </summary>
public class GetAllShopItemsRequest
{
    public bool IncludeSold { get; init; }

    public GetAllShopItemsRequest(bool includeSold)
    {
        IncludeSold = includeSold;
    }
}
