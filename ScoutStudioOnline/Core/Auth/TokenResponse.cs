using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ScoutStudioOnline.Core.Auth
{
    public class TokenResponse
    {        
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }

        [JsonPropertyName("refresh_token")]
        [JsonInclude]
        public string RefreshToken { get; set; }

        [JsonPropertyName("token_type")]        
        public string TokenType { get; set; }

        [JsonPropertyName("expires_in")]        
        public int ExpiresIn { get; set; }
    }
}
