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

namespace AnimeListApp
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            LoadAnimeLists();
        }

        private void LoadAnimeLists()
        {
            var animeLists = App.AnimeListRepository.GetAll();

            uxAnimeList.ItemsSource = animeLists.Select(t => AnimeListModel.ToModel(t)).ToList();
        }

        private void uxFileNew_Click(object sender, RoutedEventArgs e)
        {
            var window = new AnimeListwindow();

            if (window.ShowDialog() == true)
            {
                var uiAnimeListModel = window.AnimeList;

                var repositoryAnimeListModel = uiAnimeListModel.ToRepositoryModel();

                App.AnimeListRepository.Add(repositoryAnimeListModel);

                LoadAnimeLists();
            }
        }

        private AnimeListModel selectedAnimeList;

        private void uxAnimeList_SelectionCjhanged(object sender, SelectedCellsChangedEventArgs e)
        {
            selectedAnimeList = (AnimeListModel)uxAnimeList.SelectedValue;
        }

        private void uxFileChange_Click(object sender, RoutedEventArgs e)
        {
            App.AnimeListRepository.Remove(selectedAnimeList.Id);
            selectedAnimeList = null;
            LoadAnimeLists();
        }

        private void uxFileDelete_Click(object sender, RoutedEventArgs e)
        {
            uxFileDelete.IsEnabled = (selectedAnimeList != null);
        }

        private void uxFileChange_Click(object sender, RoutedEventArgs e)
        {
            var window = new AnimeListwindow();
            window.AnimeList = selectedAnimeList;

            if (window.ShowDialog() == true)
            {
                App.AnimeListRepository.Update(window.AnimeList.ToRepositoryModel());
                LoadAnimeLists();
            }
        }

        private void uxFileChange_Loaded(object sender, RoutedEventArgs e)
        {
            uxFileChange.IsEnabled = (selectedAnimeList != null);
            uxContextFileChange.IsEnabled = uxFileChange.IsEnabled;
        }

    }
}
