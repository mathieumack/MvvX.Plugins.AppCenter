using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using MSAppCenter = Microsoft.AppCenter.AppCenter;

namespace MvvX.Plugins.AppCenter
{
    public abstract class BaseAppCenterClient : IAppCenterClient
    {
        public async Task Configure(string identifier,
                                    string version,
                                    bool activateTelemetry,
                                    bool activateMetrics,
                                    bool activateCrashReports,
                                    string errorTextFileAttachment,
                                    IEnumerable<string> additionnalTextFileattachment)
        {
            MSAppCenter.Start(identifier, typeof(Analytics), typeof(Crashes));

            await Analytics.SetEnabledAsync(activateTelemetry || activateMetrics);

            await Crashes.SetEnabledAsync(activateCrashReports);

            if (activateCrashReports)
            {
                Crashes.GetErrorAttachments = (ErrorReport report) =>
                {
                    var errorAttachments = new List<ErrorAttachmentLog>();

                    if (!string.IsNullOrWhiteSpace(errorTextFileAttachment) && File.Exists(errorTextFileAttachment))
                        errorAttachments.Add(ErrorAttachmentLog.AttachmentWithText(File.ReadAllText(errorTextFileAttachment), Path.GetFileName(errorTextFileAttachment)));

                    if (additionnalTextFileattachment != null)
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            using (var archive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
                            {
                                foreach (var additionalAttachment in additionnalTextFileattachment
                                                                        .Where(filePath => !string.IsNullOrWhiteSpace(filePath) && File.Exists(filePath)))
                                {
                                    var newZipentry = archive.CreateEntry(Path.GetFileName(additionalAttachment));
                                    using (var streamWriter = new StreamWriter(newZipentry.Open()))
                                    {
                                        streamWriter.Write(File.ReadAllText(additionalAttachment));
                                    }
                                }
                            }

                            memoryStream.Seek(0, SeekOrigin.Begin);
                            errorAttachments.Add(ErrorAttachmentLog.AttachmentWithBinary(memoryStream.ToArray(), "AdditionalContent.zip", "application/zip"));
                        }
                    }

                    return errorAttachments;
                };
            }
        }

        /// <inheritdoc/>
        public void TrackEvent(string eventName)
        {
            TrackEvent(eventName, null);
        }

        /// <inheritdoc/>
        public void TrackEvent(string eventName, IDictionary<string, string> properties)
        {
            Analytics.TrackEvent(eventName, properties);
        }

        /// <inheritdoc/>
        public void TrackException(Exception ex)
        {
            TrackException(ex, null);
        }

        /// <inheritdoc/>
        public void TrackException(Exception ex, IDictionary<string, string> properties)
        {
            Crashes.TrackError(ex, properties);
        }

        /// <inheritdoc/>
        public void SetUserId(string userId)
        {
            MSAppCenter.SetUserId(userId);
        }

        /// <inheritdoc/>
        public async Task<Guid?> GetInstallationId()
        {
            return await MSAppCenter.GetInstallIdAsync();
        }
    }
}
