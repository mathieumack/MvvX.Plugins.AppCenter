# MvvX.AppCenter

Use AppCenter SDK on a MvvmCross application.
With this plugin, you can use an interface (IAppCenterClient) in order to use AppCenter functions

=========

# IC
[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=github-MvvX.Plugins.AppCenter&metric=alert_status)](https://sonarcloud.io/dashboard?id=github-MvvX.Plugins.AppCenter)
[![Build status](https://dev.azure.com/mackmathieu/Github/_apis/build/status/MvvX.Plugins.AppCenter)](https://dev.azure.com/mackmathieu/Github/_build/latest?definitionId=7)
[![NuGet package](https://buildstats.info/nuget/MvvX.Plugins.AppCenter?includePreReleases=true)](https://nuget.org/packages/MvvX.Plugins.AppCenter)

# Onboarding Instructions 

## Installation

1. Add nuget package: 

    Install-Package MvvX.Plugins.AppCenter

2. In App.xaml.cs file add the following line in usage declaration section:
    <pre>MvvX.Plugins.AppCenter;</pre>
3. In App.xaml.cs file add the following line in App class constructor: 

```c#
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

## Attach file at each crash report

You can define a default file that will be attached to an Exception report when an exception occured in the application.
To do it, set the full file path in the Configure method

```c#
    var fileToUploadSamplePath = "c:\file.log";
    var appCenterClient = Mvx.Resolve<IAppCenterClient>();
    appCenterClient.Configure(appCenterClientId, 
                                buildVersion,
                                true,
                                true,
                                true,
                                fileToUploadSamplePath,
                                null);
```
In this example, when a crash occured, the file "c:\file.log" will be attached to the exception report.

## Attach additional file at each crash report

Sometimes you need to attach more than a unique log file.

For this case, you can define additional file path to the Configure method. All files defined here will be zipped and attached to an Exception report when an exception occured in the application.

```c#
    var otherfile1 = "c:\temp\otherFile.log";
    var otherfile2 = "c:\temp\otherFile2.log";
    var appCenterClient = Mvx.Resolve<IAppCenterClient>();
    appCenterClient.Configure(appCenterClientId, 
                                buildVersion,
                                true,
                                true,
                                true,
                                null,
                                new List<string>()
                                {
                                    otherfile1,
                                    otherfile2
                                });
```
In this example, when a crash occured, a zipped file (named "AdditionalContent.zip") will be attached to the exception report.

# Support / Contribute
If you have any questions, problems or suggestions, create an issue or fork the project and create a Pull Request.