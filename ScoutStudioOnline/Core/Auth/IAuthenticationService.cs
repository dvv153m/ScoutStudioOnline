﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoutStudioOnline.Core.Auth
{
    public interface IAuthenticationService
    {
        TokenResponse TokenResponse { get; }

        Task<bool> Login(string username, string password);

        Task<bool> RefreshTokensAsync();
    }
}
