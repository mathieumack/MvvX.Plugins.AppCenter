using System;
using System.Collections.Generic;
using System.Windows;
using MvvX.Plugins.AppCenter.Wpf;
using static System.Environment;

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
        }

        private void Configure_Click(object sender, RoutedEventArgs e)
        {
            // Sample code, place your AppId here
            client.Configure("Set appcenter identifier here", "4.0.0.2", true, true, true, "Set log file path here");
        }

        private void CreateEvent_Click(object sender, RoutedEventArgs e)
        {
            client.TrackEvent("Sample name");
        }

        private void CreateSampleException_Click(object sender, RoutedEventArgs e)
        {
            client.TrackException(new ArgumentNullException(nameof(sender)), new Dictionary<string, string>());
        }
    }
}
