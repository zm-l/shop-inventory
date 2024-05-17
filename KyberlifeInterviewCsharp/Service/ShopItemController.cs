using System.Net;
using KyberlifeInterviewCsharp.Core.DTO.UseCaseRequests;
using KyberlifeInterviewCsharp.Core.UseCases;
using KyberlifeInterviewCsharp.Domain;
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
    private readonly GetAllShopItemsUseCase _getAllShopItemsUseCase;

    public ShopItemController(GetAllShopItemsUseCase getAllShopItemsUseCase)
    {
        _getAllShopItemsUseCase = getAllShopItemsUseCase;
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
        var request = new GetAllShopItemsRequest()
        {
            IncludeSold = includeSold,
        };
        var response = await _getAllShopItemsUseCase.Handle(request);
        return response.Success
            ? BaseResponse<List<ShopItem>>.Success(response.ShopItems)
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
        return BaseResponse<decimal>.Error(
            HttpStatusCode.NotImplemented,
            ["This method is not implemented yet."]
        );
    }
}