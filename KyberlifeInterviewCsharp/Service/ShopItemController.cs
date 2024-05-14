using KyberlifeInterviewCsharp.Core.DTO.UseCaseRequests;
using KyberlifeInterviewCsharp.Core.UseCases;
using KyberlifeInterviewCsharp.Domain;
using KyberlifeInterviewCsharp.Service.Requests;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace KyberlifeInterviewCsharp.Service;

[ApiController]
[Route("api/[controller]")]
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
    public async Task<ActionResult<List<ShopItem>>> GetAll([FromQuery] bool includeSold = true)
    {
        var request = new GetAllShopItemsRequest()
        {
            IncludeSold = includeSold,
        };
        var response = await _getAllShopItemsUseCase.Handle(request);
        if (response.Success)
        {
            return response.ShopItems;
        }
        return new ObjectResult(response.Errors) { StatusCode = 500 };
    }

    /// <summary>
    /// Returns the revenue of this shop i.e. the sum of all sold items.
    /// </summary>
    [HttpGet]
    [Route("get-revenue")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<decimal>> GetRevenue()
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
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<ShopItem>> AddShopItem([FromBody] AddShopItemRequest request)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Marks an item as sold. If the item is already sold, HTTP 400 is returned.
    /// Otherwise, the item is marked as sold and HTTP 200 is returned.
    /// </summary>
    [HttpPost]
    [Route("mark-as-sold")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ShopItem>> MarkItemAsSold([FromBody] string id)
    {
        throw new NotImplementedException();
    }
}