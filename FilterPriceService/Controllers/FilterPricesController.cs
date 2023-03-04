using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FilterPriceService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilterPricesController : ControllerBase
    {
        List<int> list = new List<int>()
        {
            0,
            1000000,
            2000000,
            4000000,
            7000000,
        };

        [HttpGet]
        public IActionResult Get() { return Ok(list); }
    }
}
