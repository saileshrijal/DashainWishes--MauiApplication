using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Plugin.MauiMTAdmob;

namespace DashainWishes;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
            .UseMauiMTAdmob()
            .ConfigureFonts(fonts =>
			{
                fonts.AddFont("Merienda-Regular.ttf", "MeriendaRegular");
                fonts.AddFont("Merienda-SemiBold.ttf", "MeriendaSemibold");
                fonts.AddFont("Merienda-Bold.ttf", "MeriendaBold");
                fonts.AddFont("Merienda-ExtraBold.ttf", "MeriendaExtraBold");
            });

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
