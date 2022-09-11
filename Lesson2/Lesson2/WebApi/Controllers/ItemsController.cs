using Domain;
using Domain.Items;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public sealed class ItemsController : ControllerBase
    {
        private readonly IItemsService _itemsService;

        public ItemsController(IItemsService itemsService)
        {
            _itemsService = itemsService;
        }

        [HttpGet("GetAllItems")]
        public async Task<ActionResult<ItemModel[]>> GetAllItems()
        {
            var items = await _itemsService.GetAllItems();

            return new JsonResult(items);
        }

        [HttpPost("InsertWear")]
        public async Task InsertItem([FromBody] Wear wear)
        {
            await _itemsService.WearInsert(wear);
        }
    }
}
