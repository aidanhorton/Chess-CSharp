using System;
using Windows.UI.Xaml.Media;
using Chess.Views;
using MasterDetailPageNavigation.UWP.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(MasterPage), typeof(MasterPageRenderer))]
namespace MasterDetailPageNavigation.UWP.Renderers
{
    public class MasterPageRenderer : PageRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement != null || Element == null)
            {
                return;
            }

            try
            {
                if (Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.UI.Xaml.Media.XamlCompositionBrushBase"))
                {
                    var myBrush = new AcrylicBrush
                    {
                        BackgroundSource = AcrylicBackgroundSource.HostBackdrop,
                        TintColor = Windows.UI.Color.FromArgb(255, 31, 31, 31),
                        TintOpacity = 0.7
                    };

                    Background = myBrush;
                }
                else
                {
                    var myBrush = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 31, 31, 31));

                    Background = myBrush;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }
    }
}
