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
/// Implement the endpoints in this class.
/// </summary>
[ApiController]
[Route("api/shop-item")]
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
    [Route("get-all")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<ApiResponse<List<ShopItem>>>> GetAll([FromQuery] bool includeSold = true)
    {
        var request = new GetAllShopItemsRequest()
        {
            IncludeSold = includeSold,
        };
        var response = await _getAllShopItemsUseCase.Handle(request);
        if (response.Success)
        {
            return ApiResponse<List<ShopItem>>.Success(response.ShopItems);
        }
        return ApiResponse<List<ShopItem>>.Error(HttpStatusCode.InternalServerError, response.Errors.Select(x => x.Description));
    }

    /// <summary>
    /// Returns the revenue of this shop i.e. the sum of all sold items.
    /// </summary>
    [HttpGet]
    [Route("get-revenue")]
    public async Task<ActionResult<ApiResponse<decimal>>> GetRevenue()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Adds an item to the shop. The item will be marked as unsold.
    /// If the item already exists, HTTP 400 is returned.
    /// If the price is less than or equal to 0, HTTP 400 is returned.
    /// Otherwise, the item is added and HTTP 201 is returned.
    /// </summary>
    [HttpPost]
    [Route("add-item")]
    public async Task<ActionResult<ApiResponse<int>>> AddShopItem([FromBody] AddShopItemRequest request)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Marks an item as sold. If the item is already sold, HTTP 400 is returned.
    /// Otherwise, the item is marked as sold and HTTP 200 is returned.
    /// </summary>
    [HttpPost]
    [Route("mark-as-sold")]
    public async Task<ActionResult<ApiResponse<int>>> MarkItemAsSold([FromBody] string id)
    {
        throw new NotImplementedException();
    }
}