﻿using Blazored.LocalStorage;
using Microsoft.Extensions.Configuration;
using ScoutStudioOnline.Core.Auth;
using System.Threading.Tasks;

namespace ScoutStudioOnline.Core.Unit
{    
    public class UnitService : ServiceBase
    {        
        public UnitService(IAuthenticationService authenticationService,
                           ILocalStorageService localStorageService,
                           IConfiguration config) : base(authenticationService, localStorageService, config)
        {            
        }

        public async Task<ScopeModel[]> GetScopes()
        {
            string scopesUrl = $"{BaseUrl}/api/units/getScopes";
            var scopes = await Get<ScopeModel[]>(scopesUrl, string.Empty);
            return scopes;
        }
    }
}
