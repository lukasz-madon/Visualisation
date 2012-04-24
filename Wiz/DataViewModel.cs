using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Wiz
{
    public class SeriesViewModel
    {
        private WebClient webClient = new WebClient();
        private string textFile = @"http://fatcat.ftj.agh.edu.pl/~i7madon/ca/launch.html";

        private ObservableCollection<KeyValuePair<double, double>> series = new ObservableCollection<KeyValuePair<double, double>>
        {
            new KeyValuePair<double, double>(4, 1),
            new KeyValuePair<double, double>(3, 2),
            new KeyValuePair<double, double>(2, 3),
            new KeyValuePair<double, double>(1, 4)
        };

        public SeriesViewModel()
        {
            webClient.DownloadStringCompleted += webClient_DownloadStringCompleted;
            webClient.DownloadStringAsync(new Uri(textFile));
        }

        public SeriesViewModel(Uri seriesUri)
        {
            webClient.DownloadStringCompleted += webClient_DownloadStringCompleted;
            webClient.DownloadStringAsync(seriesUri);
        }

        private void webClient_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            series[0] = new KeyValuePair<double, double>(10, 10);
        }

        public ObservableCollection<KeyValuePair<double, double>> Series
        {
            get { return series; }
        }
    }
}