// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4.Models;
using System.Collections.Generic;
using IdentityServer4;

namespace CursoIDP.IdentServer4
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Address()
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            { };

        public static IEnumerable<ApiResource> Apis =>
            new ApiResource[]
                { };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client
                {
                    ClientName = "UserApiClient",
                    ClientId = "userapiclient",
                    AllowedGrantTypes = GrantTypes.Code,
                    RedirectUris = new List<string>{ "https://localhost:5010/signin-oidc"},
                    AllowedScopes = {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Address
                    },
                    ClientSecrets = { new Secret("UserClientSecret".Sha512())},
                    RequireConsent = true,
                    PostLogoutRedirectUris = new List<string>{ "https://localhost:5010/signout-callback-oidc" }
                }
            };
    }
}