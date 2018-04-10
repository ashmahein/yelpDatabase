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
using Npgsql;

namespace Milestone1
{

    public class business
    {
        public String name { get; set; }
        public String address { get; set; }
        public String state { get; set; }
        public String city { get; set; }
        public Double Stars { get; set; }
        public int reviewCount { get; set; }
        public Double reviewRating { get; set; }
        public int numCheckins { get; set; }
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            addStates();
            addColumns();
        }

        private string connectionString()
        {
            return "Host=localhost; Username=postgres; Password=Khan1992; Database=yelpdb";
        }

        public void addStates()
        {
            using (var connection = new NpgsqlConnection(connectionString()))
            {
                connection.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = "SELECT distinct state_ FROM business ORDER BY state_;";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            stateComboBox.Items.Add(reader.GetString(0).ToString());
                        }
                    }
                }
                connection.Close();
            }

        }



        public void addColumns()
        {
            DataGridTextColumn businessNameCol = new DataGridTextColumn();
            businessNameCol.Header = "Business Name";
            businessNameCol.Binding = new Binding("name");
            businessNameCol.Width = 150;
            displayGrid.Columns.Add(businessNameCol);

            DataGridTextColumn addressCol = new DataGridTextColumn();
            addressCol.Header = "Address";
            addressCol.Binding = new Binding("address");
            addressCol.Width = 120;
            displayGrid.Columns.Add(addressCol);

            DataGridTextColumn cityCol = new DataGridTextColumn();
            cityCol.Header = "City";
            cityCol.Binding = new Binding("city");
            displayGrid.Columns.Add(cityCol);

            DataGridTextColumn stateCol = new DataGridTextColumn();
            stateCol.Header = "State";
            stateCol.Binding = new Binding("state");
            displayGrid.Columns.Add(stateCol);

            DataGridTextColumn starsCol = new DataGridTextColumn();
            starsCol.Header = "Stars";
            starsCol.Binding = new Binding("Stars");
            displayGrid.Columns.Add(starsCol);

            DataGridTextColumn reviewsCol = new DataGridTextColumn();
            reviewsCol.Header = "# of Reviews";
            reviewsCol.Binding = new Binding("reviewCount");
            displayGrid.Columns.Add(reviewsCol);

            DataGridTextColumn RatingCol = new DataGridTextColumn();
            RatingCol.Header = "avg Review Rating";
            RatingCol.Binding = new Binding("reviewRating");
            displayGrid.Columns.Add(RatingCol);

            DataGridTextColumn CheckinCol = new DataGridTextColumn();
            CheckinCol.Header = "Total Checkins";
            CheckinCol.Binding = new Binding("numCheckins");
            displayGrid.Columns.Add(CheckinCol);

        }

        private void stateComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cityListBox.Items.Clear();
            zipCodeListBox.Items.Clear();
            displayGrid.Items.Clear();
            try
            {
                using (var connection = new NpgsqlConnection(connectionString()))
                {
                    connection.Open();
                    using (var cmd = new NpgsqlCommand())
                    {
                        cmd.Connection = connection;
                        cmd.CommandText = "SELECT DISTINCT city FROM business WHERE state_ = '" + stateComboBox.SelectedItem.ToString() + "' ORDER BY city;";
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                cityListBox.Items.Add(reader.GetString(0).ToString());
                            }
                        }
                    }
                    connection.Close();
                }
            }
            catch (NullReferenceException ex)
            {

            }
        }

        private void cityListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            zipCodeListBox.Items.Clear();
            displayGrid.Items.Clear();
            try
            {
                using (var connection = new NpgsqlConnection(connectionString()))
                {
                    connection.Open();
                    using (var cmd = new NpgsqlCommand())
                    {
                        cmd.Connection = connection;
                        cmd.CommandText = "SELECT DISTINCT postalcode FROM business WHERE city = '" +
                            cityListBox.SelectedItem.ToString() + "' AND state_ = '" + stateComboBox.SelectedItem.ToString() + "'; ";
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                zipCodeListBox.Items.Add(reader.GetString(0).ToString());
                            }
                        }
                    }
                    connection.Close();
                }
            }
            catch (NullReferenceException ex)
            {

            }
        }
        private void zipCodeListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            displayGrid.Items.Clear();
            try
            {
                using (var connection = new NpgsqlConnection(connectionString()))
                {
                    connection.Open();
                    using (var cmd = new NpgsqlCommand())
                    {
                        cmd.Connection = connection;
                        cmd.CommandText = "SELECT bname,addr,city,state_,bStars,reviewCount,reviewRatings,numCheckins FROM business WHERE city = '" +
                            cityListBox.SelectedItem.ToString() + "' AND state_ = '" + stateComboBox.SelectedItem.ToString() +
                            "' AND postalcode = '" + zipCodeListBox.SelectedItem.ToString() + "'; ";
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                displayGrid.Items.Add(new business()
                                {
                                    name = reader.GetString(0),
                                    address = reader.GetString(1),
                                    city = reader.GetString(2),
                                    state = reader.GetString(3),
                                    Stars = reader.GetDouble(4),
                                    reviewCount = reader.GetInt32(5),
                                    reviewRating = reader.GetDouble(6),
                                    numCheckins = reader.GetInt32(7)
                                });
                            }
                        }

                    }
                    using (var cmd = new NpgsqlCommand())
                    {
                        cmd.Connection = connection;
                        cmd.CommandText = "SELECT DISTINCT cname FROM businessCategories as bc,Business as b WHERE bc.busID=b.busID and b.postalcode='"+
                                           zipCodeListBox.SelectedItem.ToString() + "'; ";
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                CategoryListBox.Items.Add(reader.GetString(0).ToString());
                            }
                        }
                    }
                    connection.Close();
                }
            }
            catch (NullReferenceException ex)
            {

            }
        }

        private void CategoryListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            displayGrid.Items.Clear();
            try
            {
                using (var connection = new NpgsqlConnection(connectionString()))
                {
                    connection.Open();
                    using (var cmd = new NpgsqlCommand())
                    {
                        cmd.Connection = connection;
                        cmd.CommandText = "SELECT bname,addr,city,state_,bStars,reviewCount,reviewRatings,numCheckins" +
                            " FROM business, businessCategories WHERE business.BusID=businessCategories.BusID AND city = '" +
                            cityListBox.SelectedItem.ToString() + 
                            "' AND state_ = '" + stateComboBox.SelectedItem.ToString() +
                            "' AND postalcode = '" + zipCodeListBox.SelectedItem.ToString() + 
                            "' AND cname = '" + CategoryListBox.SelectedItem.ToString() + "'; ";
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                displayGrid.Items.Add(new business()
                                {
                                    name = reader.GetString(0),
                                    address = reader.GetString(1),
                                    city = reader.GetString(2),
                                    state = reader.GetString(3),
                                    Stars = reader.GetDouble(4),
                                    reviewCount = reader.GetInt32(5),
                                    reviewRating = reader.GetDouble(6),
                                    numCheckins = reader.GetInt32(7)
                                });
                            }
                        }

                    }
                    connection.Close();
                }
            }
            catch (NullReferenceException ex)
            {
            }
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}


