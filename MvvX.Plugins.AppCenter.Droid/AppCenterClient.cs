using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

namespace MvvX.Plugins.AppCenter.Droid
{
    public class AppCenterClient : IAppCenterClient
    {
        public async Task Configure(string identifier,
                                string version,
                                bool activateTelemetry,
                                bool activateMetrics,
                                bool activateCrashReports,
                                string automaticAttachedFilePathOnCrash)
        {
            Microsoft.AppCenter.AppCenter.Start(identifier, typeof(Analytics), typeof(Crashes));

            await Analytics.SetEnabledAsync(activateTelemetry || activateMetrics);

            await Crashes.SetEnabledAsync(activateCrashReports);

            if (activateCrashReports && !string.IsNullOrWhiteSpace(automaticAttachedFilePathOnCrash))
            {
                Crashes.GetErrorAttachments = (ErrorReport report) =>
                {
                    // Your code goes here.
                    return new ErrorAttachmentLog[]
                {
                            ErrorAttachmentLog.AttachmentWithBinary(File.ReadAllBytes(automaticAttachedFilePathOnCrash), "logfile.log", "text/plain")
                };
                };
            }
        }

        public void TrackEvent(string eventName)
        {
            Analytics.TrackEvent(eventName);
        }

        public void TrackEvent(string eventName, IDictionary<string, string> properties)
        {
            Analytics.TrackEvent(eventName, properties);
        }

        public void TrackException(Exception ex, IDictionary<string, string> properties)
        {
            Crashes.TrackError(ex, properties);
        }
    }
}
