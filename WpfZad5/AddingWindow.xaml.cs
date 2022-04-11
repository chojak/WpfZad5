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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class AddingWindow : Window
    {
        public Movie Movie;
        public int Hours;
        public int Minutes;
        public AddingWindow()
        {
            InitializeComponent();
            DateInput.SelectedDate = DateTime.Now;
            DateInput.BlackoutDates.AddDatesInPast();
        }
        public AddingWindow(Movie movie)
        {
            InitializeComponent();
            DateInput.SelectedDate = DateTime.Now;

            TitleInput.Text = movie.title;
            DateInput.Text = movie.premiereDate.ToString();
            DescriptionInput.Text = movie.description;
            HourInput.Text = movie.premiereDate.Hour.ToString();
            MinuteInput.Text = movie.premiereDate.Minute.ToString();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            if (TitleInput.Text.Length > 1 && DescriptionInput.Text.Length > 1 && DateTime.TryParse(DateInput.Text, out DateTime date))
            {
                date = date.AddHours(Hours);
                date = date.AddMinutes(Minutes);

                Movie = new Movie(TitleInput.Text, date, DescriptionInput.Text);
                DialogResult = true;
                Close();
            }
            else
            {
                MessageBox.Show("Podane wartości nie są prawidłowe!");
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void HourInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (HourInput.Text == "")
                return; 

            if (!int.TryParse(HourInput.Text, out int result) || result < 0 || result > 24)
            {
                MessageBox.Show("Zła wartość godzin");
                HourInput.Text = Hours.ToString();
                return;
            }
            Hours = result;
        }

        private void MinuteInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (MinuteInput.Text == "")
                return;

            if (!int.TryParse(MinuteInput.Text, out int result) || result < 0 || result > 60)
            {
                MessageBox.Show("Zła wartość minut");
                MinuteInput.Text = Minutes.ToString();
                return;
            }
            Minutes = result;
        }
    }
}
