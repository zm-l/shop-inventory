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
    /// </summary>
    [HttpGet]
    [Route("shop-items")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<ApiResponse<List<ShopItem>>>> GetAll([FromQuery] bool includeSold = true)
    {
        var request = new GetAllShopItemsRequest()
        {
            IncludeSold = includeSold,
        };
        var response = await _getAllShopItemsUseCase.Handle(request);
        return response.Success
            ? ApiResponse<List<ShopItem>>.Success(response.ShopItems)
            : ApiResponse<List<ShopItem>>.Error(HttpStatusCode.InternalServerError, response.Errors.Select(x => x.Description));
    }

    /// <summary>
    /// Gets a specific shop item by its ID.
    /// </summary>
    [HttpGet]
    [Route("shop-item/{id:int}")]
    public async Task<ActionResult<ApiResponse<ShopItem>>> GetShopItem(int id)
    {
        return ApiResponse<ShopItem>.Error(
            HttpStatusCode.NotImplemented,
            ["This method is not implemented yet."]
        );
    }

    /// <summary>
    /// Creates or updates a shop item.
    /// </summary>
    [HttpPost]
    [Route("shop-item")]
    [Route("shop-item/{id:int}")]
    public async Task<ActionResult<ApiResponse<int>>> CreateOrUpdateShopItem([FromBody] CreateOrUpdateShopItemRequest request, int? id)
    {
        return ApiResponse<int>.Error(
            HttpStatusCode.NotImplemented,
            ["This method is not implemented yet."]
        );
    }

    /// <summary>
    /// Returns the revenue of this shop i.e. the sum of all sold items.
    /// </summary>
    [HttpGet]
    [Route("shop-items/revenue")]
    public async Task<ActionResult<ApiResponse<decimal>>> GetRevenue()
    {
        return ApiResponse<decimal>.Error(
            HttpStatusCode.NotImplemented,
            ["This method is not implemented yet."]
        );
    }
}