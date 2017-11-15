using System.Collections.Generic;
using System.Threading.Tasks;
using IdentityServer4.Services;
using IdentityServer4.Stores;
using Microsoft.AspNetCore.Http;

namespace GeneRicIdp.Server
{
    public class AccountService
    {
        private readonly IClientStore clientStore;
        private readonly IIdentityServerInteractionService interaction;
        private readonly IHttpContextAccessor httpContextAccessor;

        public AccountService(
            IIdentityServerInteractionService interaction,
            IHttpContextAccessor httpContextAccessor,
            IClientStore clientStore
        )
        {
            this.interaction = interaction;
            this.httpContextAccessor = httpContextAccessor;
            this.clientStore = clientStore;
        }


        public async Task<LoginViewModel> BuildLoginViewModelAsync(string returnUrl)
        {
            return await Task.FromResult(new LoginViewModel
            {
                ReturnUrl = returnUrl,
                ExternalProviders = new List<ExternalProvider>
                {
                    new ExternalProvider {AuthenticationScheme = "magicdance", DisplayName = "Magic Dance"},
                    new ExternalProvider {AuthenticationScheme = "bookofface", DisplayName = "Big book of faces"}
                }
            });
        }
    }
}