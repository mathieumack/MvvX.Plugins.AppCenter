using MvvmCross.Platform;
using MvvmCross.Platform.Plugins;
using MvvX.Plugins.AppCenter.Platform;

namespace MvvX.Plugins.AppCenter.Wpf
{
    public class Plugin : IMvxPlugin
    {
        public void Load()
        {
            Mvx.RegisterSingleton<IAppCenterClient>(new AppCenterClient());
        }
    }
}
