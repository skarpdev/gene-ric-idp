using Microsoft.Extensions.DependencyInjection;

namespace GeneRicIdp.Server
{
    public static class IdentityServerBuilderExtensions
    {
        public static IIdentityServerBuilder AddGeneRicUserStore(this IIdentityServerBuilder builder)
        {
            builder.Services.AddSingleton<UserService>();
            builder.AddProfileService<UserProfileService>();
            
            return builder;
        }
    }
}