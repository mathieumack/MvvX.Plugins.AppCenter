using System;
using MvvmCross;
using MvvmCross.Plugin;

namespace MvvX.Plugins.AppCenter
{
    [MvxPlugin]
    [Preserve(AllMembers = true)]
    public class Plugin : IMvxPlugin
    {
        public void Load()
        {
            Mvx.IoCProvider.RegisterSingleton<IAppCenterClient>(new AppCenterClient());
        }
    }
}