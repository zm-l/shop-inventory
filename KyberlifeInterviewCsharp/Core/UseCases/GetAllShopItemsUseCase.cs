using KyberlifeInterviewCsharp.Core.DTO;
using KyberlifeInterviewCsharp.Core.DTO.UseCaseRequests;
using KyberlifeInterviewCsharp.Core.DTO.UseCaseResponses;
using KyberlifeInterviewCsharp.Infrastructure.Repositories;

namespace KyberlifeInterviewCsharp.Core.UseCases;

public class GetAllShopItemsUseCase : IUseCase<GetAllShopItemsRequest, GetAllShopItemsResponse>
{
    private readonly IShopItemRepository _shopItemRepository;

    public GetAllShopItemsUseCase(IShopItemRepository shopItemRepository)
    {
        _shopItemRepository = shopItemRepository;
    }

    public async Task<GetAllShopItemsResponse> Handle(GetAllShopItemsRequest request)
    {
        try
        {
            var response = await _shopItemRepository.GetAll(request.IncludeSold);
            if (response.Success)
            {
                return new GetAllShopItemsResponse(response.Result, true, []);
            }

            return new GetAllShopItemsResponse([], false, response.Errors);
        }
        catch (Exception e)
        {
            return new GetAllShopItemsResponse([], false, [new Error(e.Message)]);
        }
    }
}