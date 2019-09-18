using System;
using System.Collections.Generic;
using System.Windows;
using MvvX.Plugins.AppCenter.Platform;
using MvvX.Plugins.AppCenter.Wpf;

namespace MvvX.Plugins.AppCenter.TestClient.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IAppCenterClient client;

        public MainWindow()
        {
            InitializeComponent();

            client = new AppCenterClient();
            client.Configure("<Set Api key here>", "4.0.0.2", true, true, true,
            @"log file 1.log",
            new string[] {
                @"additional file 1.log",
                @"additional file 2.log"
            });
        }

        private void CreateEvent_Click(object sender, RoutedEventArgs e)
        {
            client.TrackEvent("Sample name");
        }

        private void CreateSampleException_Click(object sender, RoutedEventArgs e)
        {
            client.TrackException(new ArgumentNullException(nameof(sender)), new Dictionary<string, string>());
        }

        private void GenerateException_Click(object sender, RoutedEventArgs e)
        {
            throw new ArgumentNullException(nameof(sender));
        }
    }
}
