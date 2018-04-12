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
using System.Windows.Shapes;

namespace AnimeListApp
{
    /// <summary>
    /// AnimeListwindow.xaml の相互作用ロジック
    /// </summary>
    public partial class AnimeListwindow : Window
    {
        public AnimeListwindow()
        {
            InitializeComponent();

            ShowInTaskbar = false;
        }

        public AnimeListModel AnimeList { get; set; }

        private void uxSubmit_Click(object sender, RoutedEventArgs e)
        {
            AnimeList = new AnimeListModel();

            AnimeList.AnimeTitle = AnimeList.uxAnimeTitle.Text;
            AnimeList.AnimeJapaneseName = uxAnimeJapaneseName.Text;
            AnimeList.AnimeStudio = uxAnimeStudio.Text;
            AnimeList.AnimeStudioJapanese = uxAnimeStudioJapanese.Text;
            AnimeList.AnimePopularityScore = 0;
            AnimeList.AnimeRatings = 0;
            AnimeList.AnimeAgeGroups = 0;
            AnimeList.CreatedDate = DateTime.Now;

            DialogResult = true;
            Close();
           
        }

        private void uxCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            AnimeList = new AnimeListModel();
            AnimeList.CreatedDate = DateTime.Now;
        }

        uxGrid.DataContext = AnimeList;
    }

    private void uxSubmit_Click(object sender, RoutedEventArgs e)
    {
        DialogResult = true;
        Close();
    }
}
