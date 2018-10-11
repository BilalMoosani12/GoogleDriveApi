using System.Collections.Generic;
using IdentityServer4.Models;

namespace Googledriveapi.Configuration
{
    public static class AuthConfig
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("scoreBoardApi", "Score Board Api")
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "client",

                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    // secret for authentication
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },

                    // scopes that client has access to
                    AllowedScopes = { "api1" }
                },
                new Client
                {
                    ClientId = "native.code",
                    ClientName = "Native Client (Code with PKCE)",
                    RequireClientSecret = false,

                    RedirectUris = { "io.identityserver.demo:/oauthredirect" },

                    AllowedGrantTypes = GrantTypes.Code,
                    RequirePkce = true,
                    AllowedScopes =
                    {
                        IdentityServer4.IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServer4.IdentityServerConstants.StandardScopes.Profile,
                    },
                    AllowOfflineAccess = true
                }
            };
        }

        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };
        }
    }
}
