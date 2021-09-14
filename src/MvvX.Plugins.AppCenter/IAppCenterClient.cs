using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MvvX.Plugins.AppCenter
{
    public interface IAppCenterClient
    {
        /// <summary>
        /// Start configuration of the AppCenter SDK on your mobile
        /// </summary>
        /// <param name="identifier"></param>
        /// <param name="version"></param>
        /// <param name="activateTelemetry"></param>
        /// <param name="activateMetrics"></param>
        /// <param name="activateCrashReports"></param>
        /// <param name="errorTextFileAttachment">File that will be attached to the crash (text file only). Can be null</param>
        /// <param name="additionnalTextFileattachment">Files that will be attached to the crash. All files will be zipped before uploading. Can be null</param>
        /// <returns></returns>
        Task Configure(string identifier, 
                                string version, 
                                bool activateTelemetry, 
                                bool activateMetrics, 
                                bool activateCrashReports,
                                string errorTextFileAttachment,
                                IEnumerable<string> additionnalTextFileattachment);

        /// <summary>
        /// Track a custom event
        /// More informations : https://docs.microsoft.com/en-us/appcenter/sdk/analytics/xamarin#custom-events
        /// </summary>
        /// <param name="eventName"></param>
        void TrackEvent(string eventName);

        /// <summary>
        /// Track a custom event
        /// More informations : https://docs.microsoft.com/en-us/appcenter/sdk/analytics/xamarin#custom-events
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="properties"></param>
        void TrackEvent(string eventName, IDictionary<string, string> properties);

        /// <summary>
        /// Track a handled error.
        /// More informations : https://docs.microsoft.com/en-us/appcenter/sdk/crashes/xamarin#handled-errors
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="properties"></param>
        void TrackException(Exception ex, IDictionary<string, string> properties);
    }
}

