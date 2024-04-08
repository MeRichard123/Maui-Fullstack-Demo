using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Core;
using FullStackTest.Services;
using Microcharts.Maui;
using Microsoft.Extensions.Logging;

namespace FullStackTest
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .UseMicrocharts()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<IHttpService, HttpService>();
            builder.Services.AddSingleton<ViewModels.ProductViewModel>();
            
#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
