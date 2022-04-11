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

namespace WpfZad5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        public List<Movie> MovieList;
        public Details detailsWid;

        private void Refresh()
        {
            MovieListBox.Items.Clear();
            foreach (var movie in MovieList)
            {
                MovieListBox.Items.Add(movie.title);
            }
        }

        private void UnselectMovie()
        {
            EditButton.IsEnabled = false;
            DeleteButton.IsEnabled = false;
            DetailsButton.IsEnabled = false;
        }

        public void DetailsClosed(object sender, System.EventArgs e)
        {
            detailsWid = null;
        }

        public MainWindow()
        {
            InitializeComponent();
            MovieList = new List<Movie>();

            MovieList.Add(new Movie("Testowy film 1", new DateTime(2022, 04, 02), "Testowy opis 1"));
            MovieList.Add(new Movie("Testowy film 2", new DateTime(2022, 04, 03), "Testowy opis 2"));
            MovieList.Add(new Movie("Testowy film 3", new DateTime(2022, 04, 04), "Testowy opis 3"));

            Refresh();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddingWindow addWid = new AddingWindow();
            addWid.Title = "Dodaj film";
            addWid.Owner = this;

            if (addWid.ShowDialog() == true)
            {
                MovieList.Add(addWid.Movie);
            }

            Refresh();
        }

        private void MovieListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            EditButton.IsEnabled = true;
            DeleteButton.IsEnabled = true;
            DetailsButton.IsEnabled = true;

            if (detailsWid != null) 
            {
                Movie movie = MovieList[MovieListBox.SelectedIndex];
                detailsWid.ChangeMovie(movie);
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            Movie movie = MovieList[MovieListBox.SelectedIndex];

            AddingWindow editWid = new AddingWindow(movie);
            editWid.Owner = this;
            editWid.Title = "Edytuj film";

            if (editWid.ShowDialog() == true)
            {
                if (detailsWid != null)
                    detailsWid.ChangeMovie(editWid.Movie);

                MovieList[MovieListBox.SelectedIndex] = editWid.Movie;
                detailsWid.Close();
                detailsWid = null;  
                Refresh();
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Movie movie = MovieList[MovieListBox.SelectedIndex];


            if (MessageBox.Show("Chcesz usunąć: " + movie.title, "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) != MessageBoxResult.No)
            {
                UnselectMovie();

                if (detailsWid != null)
                    detailsWid.Close();

                MovieList.Remove(movie);
                Refresh();
            }
        }

        private void DetailsButton_Click(object sender, RoutedEventArgs e)
        {
            Movie movie = MovieList[MovieListBox.SelectedIndex];

            if (detailsWid == null)
            {
                detailsWid = new Details(movie);
                detailsWid.Closed += DetailsClosed;
                detailsWid.Owner = this;
                detailsWid.Title = movie.title;
                detailsWid.Show();
            }
            else
            {
                detailsWid.ChangeMovie(movie);
            }
        }
    }
}
