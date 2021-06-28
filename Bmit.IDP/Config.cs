// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4.Models;
using System.Collections.Generic;

namespace Bmit.IDP
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            { 
                new IdentityResources.OpenId()
            };

        public static IEnumerable<ApiResource> Apis =>
          new ApiResource[]
          {
                new ApiResource(
                    "gymmanagerapi",
                    "Gym Manager API",
                    new List<string>() { "role" })
          };
        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {new ApiScope("name") };

        public static IEnumerable<Client> Clients =>
            new Client[] 
            { };
    }
}