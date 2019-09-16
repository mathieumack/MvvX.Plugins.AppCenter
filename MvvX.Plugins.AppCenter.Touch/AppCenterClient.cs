using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

namespace MvvX.Plugins.AppCenter.Touch
{
    public class AppCenterClient : IAppCenterClient
    {
        public async Task Configure(string identifier,
                                string version,
                                bool activateTelemetry,
                                bool activateMetrics,
                                bool activateCrashReports,
                                string[] automaticAttachedFilePathOnCrash)
        {
            Microsoft.AppCenter.AppCenter.Start(identifier, typeof(Analytics), typeof(Crashes));

            await Analytics.SetEnabledAsync(activateTelemetry || activateMetrics);

            await Crashes.SetEnabledAsync(activateCrashReports);

            if (activateCrashReports && automaticAttachedFilePathOnCrash != null)
            {
                Crashes.GetErrorAttachments = (ErrorReport report) =>
                {
                    var errorAttachments = new List<ErrorAttachmentLog>();
                    for (int i = 0; i < automaticAttachedFilePathOnCrash.Length; i++)
                    {
                        var filePath = automaticAttachedFilePathOnCrash[i];
                        if (!string.IsNullOrWhiteSpace(filePath)
                            && File.Exists(filePath))
                            errorAttachments.Add(ErrorAttachmentLog.AttachmentWithBinary(File.ReadAllBytes(filePath), Path.GetFileName(filePath), "text/plain"));
                    }
                    return errorAttachments.ToArray();
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
