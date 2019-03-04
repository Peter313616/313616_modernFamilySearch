using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Net;

namespace _313616_ModernFamily
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string dataBase;
        WebClient webClient = new WebClient();

        public MainWindow()
        {
            InitializeComponent();

            dataBase = webClient.DownloadString("http://api.tvmaze.com/singlesearch/shows?q=modern-family&embed=episodes");
            //MessageBox.Show(dataBase);
        }

        private void btnFind_Click(object sender, RoutedEventArgs e)
        {
            string episode = txtEpisode.Text;
            int location = dataBase.IndexOf(episode);
            if (location >= 193337)
            {
                lblOutPut.Content = "Season: " + dataBase.Substring(location + episode.Length + 11, 2);
            }
            else
            {
                lblOutPut.Content = "Season: " + dataBase.Substring(location + episode.Length + 11, 1);
            }
        }
    }
}
