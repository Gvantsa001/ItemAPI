using ItemAPI.Models;
using ItemAPI.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ItemsController : ControllerBase
{
    private readonly IItemService _itemService;

    public ItemsController(IItemService itemService)
    {
        _itemService = itemService;
    }

    // POST: api/items/cache
    [HttpPost("cache")]
    public IActionResult AddItemsToCache([FromBody] List<Item> items)
    {
        _itemService.AddItemsToCache(items);
        return Ok("Items added to cache.");
    }

    // GET: api/items/cache
    [HttpGet("cache")]
    public IActionResult GetItemsFromCache()
    {
        var items = _itemService.GetItemsFromCache();
        return Ok(items);
    }

    // GET: api/items/paged
    [HttpGet("paged")]
    public IActionResult GetPagedItems([FromQuery] int pageIndex = 1, [FromQuery] int pageSize = 5)
    {
        var pagedItems = _itemService.GetItemsByPage(pageIndex, pageSize);
        return Ok(pagedItems);
    }

    [HttpGet("type")]
    public IActionResult GetItemsByType([FromQuery] string type, [FromQuery] int minYear)
    {
        var items = _itemService.GetItemsByType(type, minYear);
        return Ok(items);
    }
}