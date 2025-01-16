using core;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Net.Http;
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

namespace wpfapp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        static readonly HttpClient client = new HttpClient();

        //stackoverflow
        private void searchTextChanged(object sender, TextChangedEventArgs e)
        {
            if (searchBox.Text.Length > 0)
                searchBlock.Visibility = Visibility.Collapsed;
            else
                searchBlock.Visibility = Visibility.Visible;
        }

        private async void searchButton_Click(object sender, RoutedEventArgs e)
        {
            string call = $"https://api.tvmaze.com/search/shows?q={searchBox.Text}";
            string jsonShows = "";

            //c# docs
            try
            {
                using HttpResponseMessage response = await client.GetAsync(call);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                // Above three lines can be replaced with new helper method below
                // string responseBody = await client.GetStringAsync(uri);

                jsonShows = responseBody;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", ex.Message);
            }

            //json.net docs
            JArray showSearch = JArray.Parse(jsonShows);

            // get JSON result objects into a list
            IList<JToken> results = showSearch.Children().ToList();

            // serialize JSON results into .NET objects
            IList<Show> searchResults = new List<Show>();
            foreach (JToken result in results)
            {
                // JToken.ToObject is a helper method that uses JsonSerializer internally
                Show searchResult = result["show"].ToObject<Show>();
                searchResults.Add(searchResult);
            }

            showsList.ItemsSource = searchResults;
            showsList.Items.Refresh();
        }

        private async void ShowsList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if(showsList.SelectedItem is Show selectedShow)
            {
                await ShowSeasons(selectedShow);
            }
            else if(showsList.SelectedItem is Season selectedSeason)
            {
                await ShowEpisodes(selectedSeason);
            }
        }

        private async Task ShowSeasons(Show selectedShow)
        {
            string call = $"https://api.tvmaze.com/shows/{selectedShow.Id}/seasons";
            string jsonSeasons = "";

            //c# docs
            try
            {
                using HttpResponseMessage response = await client.GetAsync(call);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                // Above three lines can be replaced with new helper method below
                // string responseBody = await client.GetStringAsync(uri);

                jsonSeasons = responseBody;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", ex.Message);
            }

            //json.net docs
            JArray seasonSearch = JArray.Parse(jsonSeasons);

            // get JSON result objects into a list
            IList<JToken> results = seasonSearch.Children().ToList();

            // serialize JSON results into .NET objects
            IList<Season> searchResults = new List<Season>();
            foreach (JToken result in results)
            {
                // JToken.ToObject is a helper method that uses JsonSerializer internally
                Season searchResult = result.ToObject<Season>();
                searchResults.Add(searchResult);
            }

            showsList.ItemsSource = searchResults;
            showsList.Items.Refresh();
        }

        private async Task ShowEpisodes(Season selectedSeason)
        {
            string call = $"https://api.tvmaze.com/seasons/{selectedSeason.Id}/episodes";
            string jsonEpisodes = "";

            //c# docs
            try
            {
                using HttpResponseMessage response = await client.GetAsync(call);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                // Above three lines can be replaced with new helper method below
                // string responseBody = await client.GetStringAsync(uri);

                jsonEpisodes = responseBody;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", ex.Message);
            }

            //json.net docs
            JArray episodeSearch = JArray.Parse(jsonEpisodes);

            // get JSON result objects into a list
            IList<JToken> results = episodeSearch.Children().ToList();

            // serialize JSON results into .NET objects
            IList<Episode> searchResults = new List<Episode>();
            foreach (JToken result in results)
            {
                // JToken.ToObject is a helper method that uses JsonSerializer internally
                Episode searchResult = result.ToObject<Episode>();
                searchResults.Add(searchResult);
            }

            showsList.ItemsSource = searchResults;
            showsList.Items.Refresh();
        }
    }
}
