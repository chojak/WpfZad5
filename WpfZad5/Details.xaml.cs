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

namespace WpfZad5
{
    /// <summary>
    /// Interaction logic for Details.xaml
    /// </summary>
    public partial class Details : Window
    {
        public Movie Movie;
        public Details(Movie movie)
        {
            InitializeComponent();
            Movie = movie;

            TitleDisplay.Text = movie.title;
            DateDisplay.Text = movie.premiereDate.ToString();
            DescriptionDisplay.Text = movie.description;
        }
        public void ChangeMovie(Movie movie)
        {
            Movie = movie;

            TitleDisplay.Text = movie.title;
            DateDisplay.Text = movie.premiereDate.ToString();
            DescriptionDisplay.Text = movie.description;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
