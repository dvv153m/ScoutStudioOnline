﻿using Blazored.LocalStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoutStudioOnline.Core
{
    public class ServiceBase
    {
        private ILocalStorageService _localStorageService;
        private IAuthenticationService _authenticationService;

        protected readonly string BaseUrl;

        public ServiceBase(IAuthenticationService authenticationService,
                           ILocalStorageService localStorageService,
                           IConfiguration config)
        {
            _localStorageService = localStorageService;
            _authenticationService = authenticationService;
            BaseUrl = config["BaseURI"];
        }

        protected async Task<T> Post<T>(string requestUrl, string requestData, bool refreshToken = true)
        {
            return await Request<T>(HttpMethod.Post, requestUrl, requestData);
        }

        protected async Task<T> Get<T>(string requestUrl, string requestData, bool refreshToken = true)
        {
            return await Request<T>(HttpMethod.Get, requestUrl, requestData);
        }

        private async Task<T> Request<T>(HttpMethod httpMethod, string requestUrl, string requestData, bool refreshToken = true)
        {
            var tokenResponse = await _localStorageService.GetItemAsync<TokenResponse>("tokenResponse");
            if (tokenResponse == null)
            {
                await _authenticationService.Login("1", "1");
                tokenResponse = await _localStorageService.GetItemAsync<TokenResponse>("tokenResponse");
            }
            var requestMessage = new HttpRequestMessage(httpMethod, requestUrl);
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", tokenResponse.AccessToken);
            if (requestData.Length > 0)
            {
                requestMessage.Content = new StringContent(requestData, Encoding.UTF8, "application/json");
            }

            using (var client = new HttpClient())
            {
                var response = await client.SendAsync(requestMessage).ConfigureAwait(false);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var responseFromServer = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    return JsonConvert.DeserializeObject<T>(responseFromServer);
                }
                else if (response.StatusCode == HttpStatusCode.Unauthorized && refreshToken)
                {
                    await _authenticationService.RefreshTokensAsync();
                    return await Request<T>(httpMethod, requestUrl, requestData, false);
                }
            }
            return default(T);
        }
    }
}
