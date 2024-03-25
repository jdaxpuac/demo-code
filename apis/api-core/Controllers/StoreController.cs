using demo_library;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace api_core.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StoreController : ControllerBase
    {

        private readonly ILogger<StoreController> _logger;
        public Store _store;

        public StoreController(ILogger<StoreController> logger)
        {
            _logger = logger;
            _store = new Store();
        }

        [HttpGet(Name = "GetStoreItem")]
        public ActionResult<Item> Get(int id)
        {
            Item item = _store.GetById(id);
            if (item == null)
            {
                return NotFound();
            }else
            {
                return Ok(item);
            }
        }

        [HttpPost(Name = "AddStoreItem")]
        public ActionResult<IActionResult> Post([FromBody] Item item)
        {
            try {
                _store.AddItem(item);
                return Ok();
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost(Name = "AddStoreItemJson")]
        public ActionResult<IActionResult> Post(string item)
        {
            try
            {
                Item itemParsed = JsonConvert.DeserializeObject<Item>(item);
                _store.AddItem(itemParsed);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
