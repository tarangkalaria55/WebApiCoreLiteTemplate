using System.Text.Json.Serialization;

namespace Domain.Settings
{
    public class JwtTokenConfig
    {
        [JsonPropertyName("Secret")]
        public string Secret { get; set; } = default!;

        [JsonPropertyName("Issuer")]
        public string Issuer { get; set; } = default!;

        [JsonPropertyName("Audience")]
        public string Audience { get; set; } = default!;

        [JsonPropertyName("AccessTokenExpiration")]
        public int AccessTokenExpiration { get; set; }

        [JsonPropertyName("RefreshTokenExpiration")]
        public int RefreshTokenExpiration { get; set; }
    }
}
