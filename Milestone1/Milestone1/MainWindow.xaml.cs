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
            //---------------Business Grid---------//
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
            //----------------------Friend data grid columns------------------//

            DataGridTextColumn friendNameCol = new DataGridTextColumn();
            friendNameCol.Header = "Name";
            friendNameCol.Binding = new Binding("Uname");
            friendNameCol.Width = 100;
            friendDataGrid.Columns.Add(friendNameCol);

            DataGridTextColumn avgStarCol = new DataGridTextColumn();
            avgStarCol.Header = "Avg Star";
            avgStarCol.Binding = new Binding("avgStars");
            friendDataGrid.Columns.Add(avgStarCol);

            DataGridTextColumn yelpingSinceCol = new DataGridTextColumn();
            yelpingSinceCol.Header = "Yelping Since";
            yelpingSinceCol.Binding = new Binding("yelpingSince");
            friendDataGrid.Columns.Add(yelpingSinceCol);

            DataGridTextColumn fansCol = new DataGridTextColumn();
            fansCol.Header = "Fans";
            fansCol.Binding = new Binding("fans");
            friendDataGrid.Columns.Add(fansCol);

            DataGridTextColumn reviewCountCol = new DataGridTextColumn();
            reviewCountCol.Header = "Votes";
            reviewCountCol.Binding = new Binding("votes");
            friendDataGrid.Columns.Add(reviewCountCol);

            //--------------------Review Data Grid---------------//

            DataGridTextColumn userNameCol = new DataGridTextColumn();
            userNameCol.Header = "User Name";
            userNameCol.Binding = new Binding("Uname");
            userNameCol.Width = 150;
            reviewDataGrid.Columns.Add(userNameCol);

            DataGridTextColumn businessCol = new DataGridTextColumn();
            businessCol.Header = "Business";
            businessCol.Binding = new Binding("Business");
            businessCol.Width = 150;
            reviewDataGrid.Columns.Add(businessCol);

            DataGridTextColumn cCol = new DataGridTextColumn();
            cCol.Header = "City";
            cCol.Binding = new Binding("city");
            reviewDataGrid.Columns.Add(cCol);

            DataGridTextColumn textCol = new DataGridTextColumn();
            textCol.Header = "Text";
            textCol.Binding = new Binding("text");
            reviewDataGrid.Columns.Add(textCol);
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
                        cmd.CommandText = "SELECT DISTINCT cname FROM businessCategories as bc,Business as b WHERE bc.busID=b.busID and b.postalcode='" +
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


        private void currentUserTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                if (currentUserTextBox.Text == "")
                {
                    userIdsListBox.Items.Clear();
                    return;
                }

                try
                {
                    using (var connection = new NpgsqlConnection(connectionString()))
                    {
                        connection.Open();
                        using (var cmd = new NpgsqlCommand())
                        {
                            cmd.Connection = connection;
                            cmd.CommandText = "SELECT userID FROM userTable WHERE uname LIKE '" + currentUserTextBox.Text.ToString() + "%'";
                            using (var reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    userIdsListBox.Items.Add(reader.GetString(0).ToString());
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
        }

        private void userIdsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            friendDataGrid.Items.Clear();
            reviewDataGrid.Items.Clear();
            try
            {
                using (var connection = new NpgsqlConnection(connectionString()))
                {
                    connection.Open();
                    using (var cmd = new NpgsqlCommand())
                    {
                        cmd.Connection = connection;
                        cmd.CommandText = "SELECT Uname,stars,fans,yelpingsince,u.funny,u.useful,u.cool" +
                            " FROM userTable as u, reviewTable as r WHERE u.userID=r.userID AND u.userID = '" +
                            userIdsListBox.SelectedItem.ToString() + "'; ";
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                nameTextBox.Text = reader.GetString(0);
                                starTextBox.Text = reader.GetDouble(1).ToString();
                                fansTextBox.Text = reader.GetDouble(2).ToString();
                                yelpingTextBox.Text = reader.GetDate(3).ToString();
                                funnyTextBox.Text = reader.GetDouble(4).ToString();
                                usefulTextBox.Text = reader.GetDouble(5).ToString();
                                coolTextBox.Text = reader.GetDouble(6).ToString();
                            }
                        }

                    }
                    //populating friends table
                    using (var cmd = new NpgsqlCommand())
                    {
                        cmd.Connection = connection;
                        cmd.CommandText = "SELECT uname,avgstar,yelpingSince,fans,(cool + funny + useful) as votes" +
                            " FROM userTable as u" +
                            " WHERE u.userID in (SELECT f.friendID FROM friendsTable as f WHERE f.userID='" +
                            userIdsListBox.SelectedItem.ToString() + "'); ";
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                friendDataGrid.Items.Add(new Friends()
                                {
                                    Uname = reader.GetString(0),
                                    avgStars = reader.GetDouble(1),
                                    yelpingSince = reader.GetDate(2).ToString(),
                                    fans = reader.GetDouble(3),
                                    votes = reader.GetDouble(4)

                                });
                            }
                        }

                    }
                    //Populating review Table
                    using (var cmd = new NpgsqlCommand())
                    {
                        cmd.Connection = connection;
                        cmd.CommandText = "SELECT uname, Bname, city, text" +
                            " FROM userTable as u, Business as b, reviewTable as r" +
                            " WHERE u.userID=r.userID AND b.busID=r.busID AND u.userID in" +
                            " (SELECT f.friendID FROM friendsTable as f WHERE f.userID='" +
                            userIdsListBox.SelectedItem.ToString() + "') ORDER BY yelpingSince DESC; ";
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                reviewDataGrid.Items.Add(new FriendReviews()
                                {
                                    Uname = reader.GetString(0),
                                    Business = reader.GetString(1),
                                    City = reader.GetString(2),
                                    text = reader.GetString(3)

                                });
                            }
                        }

                    }
                    connection.Close();
                }
            }
            catch (NullReferenceException){}
            catch (InvalidOperationException) { }
        }

        private void removeFriend_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}


