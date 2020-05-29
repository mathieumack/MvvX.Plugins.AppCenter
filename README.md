# MvvX.AppCenter

Use AppCenter SDK on a MvvmCross application.
With this plugin, you can use an interface (IAppCenterClient) in order to use AppCenter functions

=========

## IC

# IC
[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=github-MvvX.Plugins.AppCenter&metric=alert_status)](https://sonarcloud.io/dashboard?id=github-MvvX.Plugins.AppCenter)
[![Build status](https://dev.azure.com/mackmathieu/Github/_apis/build/status/MvvX.Plugins.AppCenter)](https://dev.azure.com/mackmathieu/Github/_build/latest?definitionId=7)
[![NuGet package](https://buildstats.info/nuget/MvvX.Plugins.AppCenter?includePreReleases=true)](https://nuget.org/packages/MvvX.Plugins.AppCenter)

## Platform Support

| Platform | Available 
| --- | --- |
| WPF 4.5 | &#x2713; | 
| UWP | &#x2713; | 
| Xamarin.Android | &#x2713; |
| Xamarin.iOS | &#x2713; |

## Onboarding Instructions 
1. Add nuget package: 

    Install-Package MvvX.Plugins.AppCenter

2. In App.xaml.cs file add the following line in usage declaration section:
    <pre>MvvX.Plugins.AppCenter;</pre>
3. In App.xaml.cs file add the following line in App class constructor: 
```C#
        var appCenterClientId = "Set AppCenter Id here";
        var buildVersion = "Set your application build version here"; 
        // ex : Assembly.GetExecutingAssembly().GetName().Version.ToString()
        var appCenterClient = Mvx.Resolve<IAppCenterClient>();
        appCenterClient.Configure(appCenterClientId, 
                                    buildVersion,
                                    true,
                                    true,
                                    true,
                                    null,
                                    null);
```

## Support / Contribute
If you have any questions, problems or suggestions, create an issue.