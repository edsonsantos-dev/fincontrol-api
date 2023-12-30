using FinControl.Shared.Config;

namespace FinControl.API.Extensions;

public static class SettingsLoadExtensions
{
    public static void LoadSettings(this WebApplicationBuilder builder)
    {
        Settings.Initialize(builder.Configuration.GetSection(nameof(Settings)).Get<Settings>());
    }
}