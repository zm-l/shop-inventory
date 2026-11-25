using System.Net;
using KyberlifeInterviewCsharp.Core.DTO.GatewayResponses;
using KyberlifeInterviewCsharp.Domain;
using KyberlifeInterviewCsharp.Infrastructure.Repositories;
using KyberlifeInterviewCsharp.Service.Requests;
using Microsoft.AspNetCore.Mvc;

namespace KyberlifeInterviewCsharp.Service;

/// <summary>
/// The controller for shop items.
///
/// Your task is to implement the endpoints in this class.
/// </summary>
[ApiController]
[Route("/")]
public class ShopItemController
{
    private readonly IShopItemRepository _shopItemRepository;

    public ShopItemController(IShopItemRepository shopItemRepository)
    {
        _shopItemRepository = shopItemRepository;
    }

    /// <summary>
    /// Returns all shop items within this shop.
    ///
    /// This endpoint is implemented for you.
    /// </summary>
    [HttpGet]
    [Route("shop-items")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<BaseResponse<List<ShopItem>>>> GetAll([FromQuery] bool includeSold = true)
    {
        var response = await _shopItemRepository.GetAll(includeSold);
        return response.Success
            ? BaseResponse<List<ShopItem>>.Success(response.Result)
            : BaseResponse<List<ShopItem>>.Error(HttpStatusCode.InternalServerError, response.Errors.Select(x => x.Description));
    }

    /// <summary>
    /// Endpoint #1: Creates or updates a shop item.
    /// </summary>
    [HttpPost]
    [Route("shop-item")]
    [Route("shop-item/{id:int}")]
    public async Task<ActionResult<BaseResponse<int>>> CreateOrUpdateShopItem([FromBody] CreateOrUpdateShopItemRequest request, int? id)
    {
        GetRangeResponse<ShopItem> items = await _shopItemRepository.GetAll(true);

        if (id == null)
        {
            await _shopItemRepository.AddItem(request.Name, request.Price);
            return BaseResponse<int>.Success(200);
        }

        IList<ShopItem> foundItems = items.Result.Where(x => x.Id == id).ToList();

        if (foundItems.Count == 0)
        {
            return BaseResponse<int>.Error(HttpStatusCode.NotFound, ["no id found"]);
        }

        if (foundItems[0].IsSold)
        {
            return BaseResponse<int>.Error(HttpStatusCode.BadRequest, ["item is sold"]);
        }
        
        
        
        
        await Task.CompletedTask;
        return BaseResponse<int>.Error(
            HttpStatusCode.NotImplemented,
            ["This method is not implemented yet."]
        );
    }

    /// <summary>
    /// Endpoint #2: Gets a specific shop item by its ID.
    /// </summary>
    [HttpGet]
    [Route("shop-item/{id:int}")]
    public async Task<ActionResult<BaseResponse<ShopItem>>> GetShopItem(int id)
    {
        await Task.CompletedTask;
        return BaseResponse<ShopItem>.Error(
            HttpStatusCode.NotImplemented,
            ["This method is not implemented yet."]
        );
    }

    /// <summary>
    /// Endpoint #3: Returns the revenue of this shop i.e. the sum of all sold items.
    /// </summary>
    [HttpGet]
    [Route("shop-items/revenue")]
    public async Task<ActionResult<BaseResponse<decimal>>> GetRevenue()
    {
        await Task.CompletedTask;
        return BaseResponse<decimal>.Error(
            HttpStatusCode.NotImplemented,
            ["This method is not implemented yet."]
        );
    }
}
