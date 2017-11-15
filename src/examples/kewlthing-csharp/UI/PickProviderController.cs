using Microsoft.AspNetCore.Mvc;

namespace kewlthing_csharp.UI
{
    public class PickProviderController : Controller
    {
        [HttpPost]
        public IActionResult Index([FromBody]PickProviderInput input)
        {
            return View(input);
        }
    }
}