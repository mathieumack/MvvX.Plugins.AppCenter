using System;
using System.Collections.Generic;
using System.Windows;
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
            client.Configure("<Set Api key here>", "4.0.0.2", true, true, true, new string[] 
            {
                @"<Set file path to log file 1 here>",
                @"<Set file path to log file 2 here>"
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
