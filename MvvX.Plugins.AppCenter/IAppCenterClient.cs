using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MvvX.Plugins.AppCenter
{
    public interface IAppCenterClient
    {
        /// <summary>
        /// Start configuration of the api with your app identifier
        /// </summary>
        /// <param name="identifier"></param>
        Task Configure(string identifier, 
                                string version, 
                                bool activateTelemetry, 
                                bool activateMetrics, 
                                bool activateCrashReports,
                                string automaticAttachedFilePathOnCrash);

        void TrackEvent(string eventName);

        void TrackEvent(string eventName, IDictionary<string, string> properties);

        void TrackException(Exception ex, IDictionary<string, string> properties);
    }
}

