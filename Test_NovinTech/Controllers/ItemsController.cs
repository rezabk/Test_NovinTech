using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Items;

namespace Test_NovinTech.Controllers
{


    public class ItemsController : ApiControllerBase
    {
        [HttpPost("/create")]
        public async Task<ActionResult<int>> CreateItem(CreateItemRequest request)
        {
            return await Mediator.Send(new CreateItemCommand(request));
        }

        [HttpGet]
        public async Task<ActionResult<List<ItemDTO>>> GetItems()
        {
            return await Mediator.Send(new GetItemsQuery());
        }
    }
}
