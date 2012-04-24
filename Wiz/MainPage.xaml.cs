using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Browser;
using System.Windows.Controls;

namespace Wiz
{
    public partial class MainPage : UserControl
    {
        private const string urlParam = "url";

        public MainPage()
        {
            InitializeComponent();
            this.Loaded += MainPage_Loaded;
        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            //Uri uri = new Uri("http://n.com/index.html?url=http://n.com/sym/sym1.txt&url=http://n.com/sym/sym1.txt");

            var parameters = HtmlPage.Document.QueryString;
            //var query = HtmlPage.Document.QueryString["foo"];
            if (parameters.ContainsKey(urlParam))
            {
                var url = parameters[urlParam];
                Uri fileUri;
                if (Uri.TryCreate(url, UriKind.Absolute, out fileUri))
                {
                    this.DataContext = new SeriesViewModel(fileUri);
                    urlTextBox.Text = url;
                }
                else
                {
                    urlTextBox.Text = "malformed simulation data url";
                }
            }
            else
            {
                urlTextBox.Text = "No file location in url";
            }
        }
    }
}