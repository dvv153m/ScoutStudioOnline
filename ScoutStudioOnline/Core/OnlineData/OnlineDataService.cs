﻿using Blazored.LocalStorage;
using Microsoft.Extensions.Configuration;
using ScoutStudioOnline.Core.Auth;
using ScoutStudioOnline.Infrastructure;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ScoutStudioOnline.Core.OnlineData
{    
    public class OnlineDataService : ServiceBase
    {                      
        public OnlineDataService(IAuthenticationService authenticationService,
                                 ILocalStorageService localStorageService,
                                 IConfiguration config) : base(authenticationService, localStorageService, config)
        {            
        }

        public async Task<IEnumerable<OnlineDataResponse>> GetOnlineData()
        {            
            string onlineDataUrl = $"{BaseUrl}/api/onlinedata/getOnlineData";
            string requestData = @"{""skip"": 0, ""take"": 10, ""filter"": 1, ""orderDescending"": false}";
            var unitsOnlineData = await Post<Page<OnlineDataResponse>>(onlineDataUrl, requestData);
            return unitsOnlineData.Data;
        }        
    }
}
