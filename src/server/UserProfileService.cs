using System.Threading.Tasks;
using IdentityServer4.Models;
using IdentityServer4.Services;

namespace GeneRicIdp.Server
{
    public class UserProfileService : IProfileService
    {
        private readonly UserService userService;

        public UserProfileService(UserService userService)
        {
            this.userService = userService;
        }

        public Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            throw new System.NotImplementedException();
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            throw new System.NotImplementedException();
        }
    }
}