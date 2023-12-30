namespace FinControl.Shared.Config;

public class Settings
{
    public static Settings? Instance { get; private set; }

    public static void Initialize(Settings? settings)
    {
        Instance = settings;
    }

    public required string Secret { get; set; }
    public required string Issuer { get; set; }
    public required string Audience { get; set; }
    public required string TokenTypeAccessToken { get; set; }
    public required string TokenTypeRefreshToken { get; set; }
}