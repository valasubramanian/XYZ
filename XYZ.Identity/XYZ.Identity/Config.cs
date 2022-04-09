using System.Security.Claims;
using System.Data.Common;
using IdentityServer4.Models;
using System.Collections.Generic;
using IdentityServer4;

namespace XYZ.Identity
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
                new IdentityResource("role", "roles of user", new List<string>() { "role" })
            };
        public static IEnumerable<ApiResource> ApiResources =>
            new ApiResource[]
            {
                new ApiResource("x.api", "X.API", new [] { "role" })
                {
                     Scopes = new [] { "x.api" }
                },
                new ApiResource("y.api", "Y.API", new [] { "role" })
                {
                     Scopes = new [] { "y.api" }
                }
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("x.api", "X.API"),
                new ApiScope("y.api", "Y.API")
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                // interactive client using code flow + pkce
                // xyz.ui -> x.api
                new Client
                {
                    ClientId = "client-id-112317298-interactive",
                    ClientSecrets = 
                    { 
                        new Secret("49C1A7E1-0C79-4A89-A3D6-A37998FB86B0".Sha256()) 
                    },
                    AllowedGrantTypes = GrantTypes.Code,
                    RequirePkce = true,
                    RedirectUris = { "https://localhost:5000/signin-oidc" },
                    FrontChannelLogoutUri = "https://localhost:5000/signout-oidc",
                    PostLogoutRedirectUris = { "https://localhost:5000/signout-callback-oidc" },
                    AllowedScopes = 
                    { 
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "role",
                        "x.api",
                        "y.api"
                    }
                },
                // m2m client credentials flow client
                // x.api -> y.api
                new Client
                {
                    ClientId = "client-id-453434-m2m",
                    ClientName = "Client Credentials Client",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret("511536EF-F270-4058-80CA-1C89C192F69A".Sha256()) },
                    AllowedScopes = { "y.api" }
                }
            };
    }
}