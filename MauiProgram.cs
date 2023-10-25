using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;

namespace MauiBugScrollViewSizingiOS
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

#if IOS
            Microsoft.Maui.Handlers.ScrollViewHandler.Mapper.AppendToMapping(nameof(IScrollView.ContentSize), (h, v) =>
            {
                var contentSize = h.VirtualView.ContentSize;

                if (contentSize.IsZero)
                    return;

                var uiScrollView = h.PlatformView;
                var container = uiScrollView.Subviews.FirstOrDefault(x => x.Tag == 0x845fed);

                if (container == null || container.Bounds.Height == contentSize.Height)
                {
                    return;
                }

                container.Bounds = new CoreGraphics.CGRect(container.Bounds.X, container.Bounds.Y, contentSize.Width, contentSize.Height);

                h.VirtualView.InvalidateMeasure();
            });
#endif

            return builder.Build();
        }
    }
}
