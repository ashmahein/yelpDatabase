﻿using System;
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
        private List<String> DOW { get; set; }
        private List<String> times { get; set; }
        private Friends row_info { get; set; }
        //private FriendReviews reviewTable { get; set; }
        //private List<String> friendsReviewItems { get; set; }
        public MainWindow()
        {
            
            InitializeComponent();
            DOW = new List<string>(new String[] { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" });
            times = new List<string>(new String[] { "00:00", "01:00", "02:00", "03:00", "04:00", "05:00", "06:00",
                                                   "07:00", "08:00", "09:00", "10:00", "11:00", "12:00", "13:00",
                                                   "14:00", "15:00", "16:00", "17:00", "18:00", "19:00", "20:00",
                                                   "21:00", "22:00", "23:00"});
            foreach(var item in DOW)
            {
                dowComboBox.Items.Add(item);
            }
            foreach(var item in times)
            {
                FromComboBox.Items.Add(item);
                ToComboBox.Items.Add(item);
            }
            addStates();
            addColumns();
            searchButton.IsEnabled = false;
            addButton.IsEnabled = false;
            removeButton.IsEnabled = false;

        }

        private string connectionString()
        {
            return "Host=localhost; Username=postgres; Password=madera111; Database=yelpdb";
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

            DataGridTextColumn friendIDCol = new DataGridTextColumn();
            friendIDCol.Header = "Friend ID";
            friendIDCol.Binding = new Binding("userID");
            friendDataGrid.Columns.Add(friendIDCol);

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
            searchButton.IsEnabled = false;
            CategoryListBox.Items.Clear();
            SelectedCategories.Items.Clear();
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
            catch (NullReferenceException)
            {

            }
        }

        private void cityListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            zipCodeListBox.Items.Clear();
            displayGrid.Items.Clear();
            searchButton.IsEnabled = false;
            CategoryListBox.Items.Clear();
            SelectedCategories.Items.Clear();
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
            catch (NullReferenceException)
            {

            }
        }

        private void zipCodeListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            displayGrid.Items.Clear();
            CategoryListBox.Items.Clear();
            SelectedCategories.Items.Clear();
            searchButton.IsEnabled = true;
            try
            {
                using (var connection = new NpgsqlConnection(connectionString()))
                {
                    connection.Open();
                    using (var cmd = new NpgsqlCommand())
                    {
                        cmd.Connection = connection;
                        cmd.CommandText = "SELECT DISTINCT cname FROM businessCategories as bc,Business as b WHERE bc.busID=b.busID and"+
                            " city = '" + cityListBox.SelectedItem.ToString() +
                            "' AND state_ = '" + stateComboBox.SelectedItem.ToString() + 
                            "' AND b.postalcode='" + zipCodeListBox.SelectedItem.ToString() + "'; ";
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
            catch (NullReferenceException)
            {

            }
        }

        private void CategoryListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            displayGrid.Items.Clear();
            addButton.IsEnabled = true;
        }

        private void SelectedCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            removeButton.IsEnabled = true;
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            SelectedCategories.Items.Add(CategoryListBox.SelectedItem);
            CategoryListBox.UnselectAll();
            CategoryListBox.SelectedIndex = -1;
            addButton.IsEnabled = false;
        }

        private void removeButton_Click(object sender, RoutedEventArgs e)
        {
            SelectedCategories.Items.Remove(SelectedCategories.SelectedItem);
            SelectedCategories.UnselectAll();
            removeButton.IsEnabled = false;
        }

        private void friendDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            removeButton.IsEnabled = true;
            try
            {
                row_info = (Friends)friendDataGrid.SelectedItem;
            }
            catch { }
        }

        private void removeFriend_Click(object sender, RoutedEventArgs e)
        {

            var removeFriend = row_info.userID.ToString();
            var user = userIdsListBox.SelectedItem.ToString();
            var friendname = row_info.Uname;

            try
            {
                using (var connection = new NpgsqlConnection(connectionString()))
                {
                    connection.Open();
                    using (var cmd = new NpgsqlCommand())
                    {
                        cmd.Connection = connection;

                        cmd.CommandText = "DELETE FROM friendsTable WHERE userID ='" + user + "'friendID ='" + removeFriend + "';";
                    }
                    //Might also need to add code to reload the friends review comments section as well.

                    friendDataGrid.Items.Remove(friendDataGrid.SelectedItem);
                    friendDataGrid.Items.Refresh();
                    removeButton.IsEnabled = false;

                    reviewDataGrid.Items.Clear();
                    reviewDataGrid.Items.Refresh();

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
            catch (NullReferenceException)
            {

            }
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            int count = 0;
            int countCategories = 0;
            displayGrid.Items.Clear();
            StringBuilder sb = new StringBuilder();
            try
            {
                using (var connection = new NpgsqlConnection(connectionString()))
                {
                    connection.Open();
                    using (var cmd = new NpgsqlCommand())
                    {
                        cmd.Connection = connection;
                        if (SelectedCategories.Items.Count >= 1)
                        {
                            foreach (var item in SelectedCategories.Items)
                            {
                                countCategories++;
                                sb.Append("'" + item + "',");
                            }
                            // remove extra ,
                            sb.Remove(sb.Length - 1, 1);
                            cmd.CommandText = "SELECT bname,addr,city,state_,bStars,reviewCount,reviewRatings,numCheckins" +
                            " FROM business, businessCategories WHERE business.BusID=businessCategories.BusID AND city = '" +
                            cityListBox.SelectedItem.ToString() +
                            "' AND state_ = '" + stateComboBox.SelectedItem.ToString() +
                            "' AND postalcode = '" + zipCodeListBox.SelectedItem.ToString() +
                            "' AND cname in (" + sb + ") GROUP BY bname,addr,city,state_,bStars,reviewCount,reviewRatings,numCheckins" +
                            " HAVING count(*) = " + countCategories.ToString() + "; ";
                        }
                        else if (CategoryListBox.SelectedIndex == -1)
                        {
                            cmd.CommandText = "SELECT bname,addr,city,state_,bStars,reviewCount,reviewRatings,numCheckins FROM business WHERE city = '" +
                                cityListBox.SelectedItem.ToString() + "' AND state_ = '" + stateComboBox.SelectedItem.ToString() +
                                "' AND postalcode = '" + zipCodeListBox.SelectedItem.ToString() + "'; ";
                        }
                        else
                        {
                            cmd.CommandText = "SELECT bname,addr,city,state_,bStars,reviewCount,reviewRatings,numCheckins" +
                            " FROM business, businessCategories WHERE business.BusID=businessCategories.BusID AND city = '" +
                            cityListBox.SelectedItem.ToString() +
                            "' AND state_ = '" + stateComboBox.SelectedItem.ToString() +
                            "' AND postalcode = '" + zipCodeListBox.SelectedItem.ToString() +
                            "' AND cname = '" + CategoryListBox.SelectedItem.ToString() + "'; ";
                        }

                        //if the day and times are provided
                        if (dowComboBox.SelectedIndex == -1 && ToComboBox.SelectedIndex == -1 && FromComboBox.SelectedIndex == -1)
                        {
                            //remove the string from group key word to add to the query
                            String temp = cmd.CommandText;
                            int index = temp.IndexOf("GROUP");
                            temp = temp.Substring(0, index);

                            cmd.CommandText = temp + " AND dayofweek = '" + dowComboBox.SelectedItem.ToString() + 
                                                     "' AND opens <= '" + FromComboBox.SelectedIndex.ToString() +
                                                     "' AND closed = '" + ToComboBox.SelectedIndex.ToString() + "'; ";
                            if (SelectedCategories.Items.Count >= 1)
                            {
                                cmd.CommandText += "' AND cname in (" + sb + ") GROUP BY bname,addr,city,state_,bStars,reviewCount,reviewRatings,numCheckins" +
                                                   " HAVING count(*) = " + countCategories.ToString() + "; ";
                            }

                        }
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                count++;
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
                numOfBusinessLabel.Content = "# of busnesses " + count.ToString();

            }
            catch (NullReferenceException) { }
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
                catch (NullReferenceException) { }
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
                        cmd.CommandText = "SELECT uname,avgstar,yelpingSince,fans,(cool + funny + useful) as votes, userID" +
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
                                    votes = reader.GetDouble(4),
                                    userID = reader.GetString(5)
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
    }
}


