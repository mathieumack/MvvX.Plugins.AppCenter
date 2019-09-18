using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MvvX.Plugins.AppCenter
{
    public interface IAppCenterClient
    {
        /// <summary>
        /// 
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

        void TrackEvent(string eventName);

        void TrackEvent(string eventName, IDictionary<string, string> properties);

        void TrackException(Exception ex, IDictionary<string, string> properties);
    }
}

