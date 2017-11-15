using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace GeneRicIdp.Server
{
    [SecurityHeaders]
    public class LoginController : Controller
    {
        private readonly AccountService accountService;
        private readonly HtmlGetter htmlGetter;

        public LoginController(AccountService accountService, HtmlGetter htmlGetter)
        {
            this.accountService = accountService;
            this.htmlGetter = htmlGetter;
        }

        [HttpGet]
        public async Task<IActionResult> IndexAsync(string returnUrl)
        {
            var viewModel = await accountService.BuildLoginViewModelAsync(returnUrl);

            var html = await htmlGetter.GetPickProviderHtmlAsync("http://localhost:5500/PickProvider", viewModel);
            
            return Content(html, "text/html");
        }

        [HttpPost]
        public async Task<IActionResult> LoginBackendAsync()
        {
            await Task.CompletedTask;
            return Redirect("/yay");
        }
    }
}