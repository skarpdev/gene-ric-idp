using System.Collections.Generic;
using IdentityServer4;
using IdentityServer4.Models;

namespace GeneRicIdp.Server
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Address(),
                new IdentityResource("roles", "Your roles", new List<string> { "role" }),
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("someapi", "Some API", new List<string> {"role"})
                {
                    // required to use Reference Tokens, as the API will then
                    // communicate with IDP
                    ApiSecrets = { new Secret("apisecret".Sha256()) }
                }
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientName = "Kewl Thing Node.js",
                    ClientId = "kewlthing-nodejs",
                    AllowedGrantTypes = GrantTypes.Hybrid,
                    
                    // do not show the consent screen, when
                    // logging in
                    RequireConsent = false,
                    
                    // The type of access token to get
                    // Reference, means that the IDP holds the actual token
                    // meaning that the API must use the IDP to validate
                    // the given access token - this makes it easier to revoke them!
                    // The default value is "JWT", which is self-contained
                    // and therefore harder to revoke.
                    AccessTokenType = AccessTokenType.Reference,
                    
                    // The lifetime of the identity token.
                    // The token used to get a claims identity.
                    // This is typically used just after authentication
                    // so lifetime defaults to 5 minutes
                    //IdentityTokenLifetime = 300,
                    
                    // The lifetime of the authorization code,
                    // which is exchanged for tokens.
                    // This happens as part of the hybrid flow.
                    // Also defaults to 5 minutes
                    //AuthorizationCodeLifetime = 300,
                    
                    // The lifetime of the access token.
                    // This defaults to 1 hour.
                    //AccessTokenLifetime = 3600,
                    
                    // Update claims on the access token
                    // when the access token is refreshed.
                    // Otherwise the default lifetime of 30 days
                    // will mean that changes to claims will
                    // not be apparent until up to 30 days later.
                    UpdateAccessTokenClaimsOnRefresh = true,
                    
                    // Means that the client can call us
                    // without being logged in to the us.
                    // This is required for refreshing tokens.
                    AllowOfflineAccess = true,
                    
                    RedirectUris = new List<string>
                    {
                        "http://localhost:5111/signin-oidc"
                    },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Address,
                        "roles",
                        "someapi"
                    },
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    PostLogoutRedirectUris =
                    {
                        "http://localhost:5111/signout-callback-oidc"
                    }
                }
            };
        }
    }
}