namespace API.Settings;

public class JwtSettings
{
    public bool ValidateIssuer { get; init; }
    public bool ValidateAudience { get; init; }
    public bool ValidateLifetime { get; init; }
    public bool ValidateIssuerSigningKey { get; init; }
    public string ValidIssuer { get; init; }
    public string ValidAudience { get; init; }
    public string SigningKey { get; init; }
    public int ValidForInMinutes { get; init; }
}
