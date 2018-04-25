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
using System.Reflection;

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
        private business brow_info { get; set; }
        //private Friends row_info { get; set; }
        private double calDistance { get; set; }

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
            checkinButton.IsEnabled = false;
            showReviewButton.IsEnabled = false;
            //set default location
            latitudeTextBox.Text = "33.3187306943";
            longitudeTextBox.Text = "-111.943387985";
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
            #region business grid
            //---------------Business Grid---------//
            DataGridTextColumn businessNameCol = new DataGridTextColumn();
            businessNameCol.Header = "Business Name";
            businessNameCol.Binding = new Binding("name");
            businessNameCol.Width = 150;
            displayGrid.Columns.Add(businessNameCol);
            sortByComboBox.Items.Add(businessNameCol.Header);

            DataGridTextColumn addressCol = new DataGridTextColumn();
            addressCol.Header = "Address";
            addressCol.Binding = new Binding("address");
            addressCol.Width = 150;
            displayGrid.Columns.Add(addressCol);

            DataGridTextColumn cityCol = new DataGridTextColumn();
            cityCol.Header = "City";
            cityCol.Binding = new Binding("city");
            displayGrid.Columns.Add(cityCol);

            DataGridTextColumn stateCol = new DataGridTextColumn();
            stateCol.Header = "State";
            stateCol.Binding = new Binding("state");
            displayGrid.Columns.Add(stateCol);

            DataGridTextColumn distanceCol = new DataGridTextColumn();
            distanceCol.Header = "Dist";
            distanceCol.Binding = new Binding("distance");
            displayGrid.Columns.Add(distanceCol);
            sortByComboBox.Items.Add(distanceCol.Header);

            DataGridTextColumn starsCol = new DataGridTextColumn();
            starsCol.Header = "Stars";
            starsCol.Binding = new Binding("Stars");
            displayGrid.Columns.Add(starsCol);
            sortByComboBox.Items.Add(starsCol.Header);

            DataGridTextColumn reviewsCol = new DataGridTextColumn();
            reviewsCol.Header = "# of Reviews";
            reviewsCol.Binding = new Binding("reviewCount");
            reviewsCol.Width = 50;
            displayGrid.Columns.Add(reviewsCol);
            sortByComboBox.Items.Add(reviewsCol.Header);

            DataGridTextColumn RatingCol = new DataGridTextColumn();
            RatingCol.Header = "Review Ratings";
            RatingCol.Binding = new Binding("reviewRating");
            RatingCol.Width = 50;
            displayGrid.Columns.Add(RatingCol);
            sortByComboBox.Items.Add(RatingCol.Header);

            DataGridTextColumn CheckinCol = new DataGridTextColumn();
            CheckinCol.Header = "Total Checkins";
            CheckinCol.Binding = new Binding("numCheckins");
            CheckinCol.Width = 50;
            displayGrid.Columns.Add(CheckinCol);
            sortByComboBox.Items.Add(CheckinCol.Header);

            DataGridTextColumn idCol = new DataGridTextColumn();
            idCol.Header = "busID";
            idCol.Binding = new Binding("busID");
            idCol.Width = 10;
            displayGrid.Columns.Add(idCol);
            #endregion

            

            #region user friends
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
#endregion

            #region friends review
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
            #endregion
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

                        cmd.CommandText = "DELETE FROM friendsTable WHERE userID ='" + user + "' AND friendID ='" + removeFriend + "';";
                        int numDeletions = cmd.ExecuteNonQuery();
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
            int day = 0, to = 0, from = 0;
            day = dowComboBox.SelectedIndex;
            to = ToComboBox.SelectedIndex;
            from = FromComboBox.SelectedIndex;
            List<business> bList = new List<business>();
            StringBuilder closedQuery = new StringBuilder();
            

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
                            cmd.CommandText = "SELECT bname,addr,city,state_,bStars,reviewCount,reviewRatings,numCheckins,latitude,longitude,business.busid" +
                            " FROM business, businessCategories WHERE business.BusID=businessCategories.BusID AND city = '" +
                            cityListBox.SelectedItem.ToString() +
                            "' AND state_ = '" + stateComboBox.SelectedItem.ToString() +
                            "' AND postalcode = '" + zipCodeListBox.SelectedItem.ToString() +
                            "' AND cname in (" + sb + ") GROUP BY bname,addr,city,state_,bStars,reviewCount,reviewRatings,numCheckins,latitude,longitude,business.busid" +
                            " HAVING count(*) = " + countCategories.ToString() + " ORDER BY bname ";
                            if (day != -1 && to != -1 && from != -1)
                            {
                                //remove the string from group key word to add to the query
                                String temp = cmd.CommandText;
                                int index = 0;
                                index = temp.IndexOf("FROM");
                                if (index > 0)
                                    temp = temp.Substring(0, index);
                                closedQuery.Append("SELECT distinct opens FROM business as b, Hours as h WHERE b.busID = h.busID AND opens <='"
                                    + FromComboBox.SelectedIndex.ToString() + ":00' or opens = '" + ToComboBox.SelectedIndex.ToString() + ":00' ");

                                cmd.CommandText = temp + " FROM business, hours, businessCategories WHERE business.BusID = businessCategories.BusID AND business.BusID=hours.BusID"+
                                                  " AND city = '" + cityListBox.SelectedItem.ToString() +
                                                  "' AND state_ = '" + stateComboBox.SelectedItem.ToString() +
                                                  "' AND postalcode = '" + zipCodeListBox.SelectedItem.ToString() +
                                                  "' AND dayofweek = '" + dowComboBox.SelectedItem.ToString() +
                                                  "' AND opens <= '" + FromComboBox.SelectedIndex.ToString() +
                                                  ":00' AND closed IN (" + closedQuery +
                                                  ") AND cname in (" + sb + ")";
                                cmd.CommandText += " GROUP BY bname,addr,city,state_,bStars,reviewCount,reviewRatings,numCheckins,latitude,longitude,business.busid" +
                                                   " HAVING count(*) = " + countCategories.ToString() + " ORDER BY bname";

                            }
                        }
                        else if (CategoryListBox.SelectedIndex == -1)
                        {
                            cmd.CommandText = "SELECT bname,addr,city,state_,bStars,reviewCount,reviewRatings,numCheckins,latitude,longitude,business.busid" +
                                " FROM business WHERE city = '" +
                                cityListBox.SelectedItem.ToString() + "' AND state_ = '" + stateComboBox.SelectedItem.ToString() +
                                "' AND postalcode = '" + zipCodeListBox.SelectedItem.ToString() + "' ORDER BY bname ";
                            if (day != -1 && to != -1 && from != -1)
                            {
                                //remove the string from group key word to add to the query
                                String temp = cmd.CommandText;
                                int index = 0;
                                index = temp.IndexOf("FROM");
                                if (index > 0)
                                    temp = temp.Substring(0, index);
                                closedQuery.Append("SELECT distinct opens FROM business as b, Hours as h WHERE b.busID = h.busID AND opens <='"
                                    + FromComboBox.SelectedIndex.ToString() + ":00' or opens = '" + ToComboBox.SelectedIndex.ToString() + ":00' ");

                                cmd.CommandText = temp + " FROM business, hours WHERE business.BusID=hours.BusID" +
                                                  " AND city = '" + cityListBox.SelectedItem.ToString() +
                                                  "' AND state_ = '" + stateComboBox.SelectedItem.ToString() +
                                                  "' AND postalcode = '" + zipCodeListBox.SelectedItem.ToString() +
                                                  "' AND dayofweek = '" + dowComboBox.SelectedItem.ToString() +
                                                  "' AND opens <= '" + FromComboBox.SelectedIndex.ToString() +
                                                  ":00' AND closed IN (" + closedQuery +
                                                  ") ORDER BY bname";
                            }
                        }
                        else
                        {
                            cmd.CommandText = "SELECT bname,addr,city,state_,bStars,reviewCount,reviewRatings,numCheckins,latitude,longitude,business.busid" +
                            " FROM business, businessCategories WHERE business.BusID=businessCategories.BusID AND city = '" +
                            cityListBox.SelectedItem.ToString() +
                            "' AND state_ = '" + stateComboBox.SelectedItem.ToString() +
                            "' AND postalcode = '" + zipCodeListBox.SelectedItem.ToString() +
                            "' AND cname = '" + CategoryListBox.SelectedItem.ToString() + "' ORDER BY bname ";
                            if (day != -1 && to != -1 && from != -1)
                            {
                                //remove the string from group key word to add to the query
                                String temp = cmd.CommandText;
                                int index = 0;
                                index = temp.IndexOf("FROM");
                                if (index > 0)
                                    temp = temp.Substring(0, index);
                                closedQuery.Append("SELECT distinct opens FROM business as b, Hours as h WHERE b.busID = h.busID AND opens <='"
                                    + FromComboBox.SelectedIndex.ToString() + ":00' or opens = '" + ToComboBox.SelectedIndex.ToString() + ":00' ");

                                cmd.CommandText = temp + " FROM business, hours, businessCategories WHERE business.BusID = businessCategories.BusID AND business.BusID=hours.BusID" +
                                                  " AND city = '" + cityListBox.SelectedItem.ToString() +
                                                  "' AND state_ = '" + stateComboBox.SelectedItem.ToString() +
                                                  "' AND postalcode = '" + zipCodeListBox.SelectedItem.ToString() +
                                                  "' AND dayofweek = '" + dowComboBox.SelectedItem.ToString() +
                                                  "' AND opens <= '" + FromComboBox.SelectedIndex.ToString() +
                                                  ":00' AND closed IN (" + closedQuery +
                                                  ") AND cname = '" + CategoryListBox.SelectedItem.ToString() + "' ORDER BY bname ";

                            }
                        }
                        cmd.CommandTimeout = 0;
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                count++;
                                calDistance = Math.Round(DistanceTo(reader.GetDouble(8), reader.GetDouble(9), Convert.ToDouble(latitudeTextBox.Text), Convert.ToDouble(longitudeTextBox.Text)), 2);
                                bList.Add(new business()
                                {
                                    name = reader.GetString(0),
                                    address = reader.GetString(1),
                                    city = reader.GetString(2),
                                    state = reader.GetString(3),
                                    Stars = reader.GetDouble(4),
                                    reviewCount = reader.GetInt32(5),
                                    reviewRating = Math.Round(reader.GetDouble(6), 2),
                                    numCheckins = reader.GetInt32(7),
                                    distance = calDistance,
                                    busID = reader.GetString(10)
                                });
                            }
                        }

                        bList = filterByAttributes(bList, cmd);
                        bList = filterByPriceLevel(bList, cmd);
                        bList = filterByMeals(bList, cmd);
                    }
                    connection.Close();

                    count = displayBusinesses(bList);
                }
                numOfBusinessLabel.Content = "# of busnesses " + count.ToString();

            }
            catch (NullReferenceException) { }
        }

        private int displayBusinesses(List<business> bList)
        {
            int count = 0;
            foreach (business item in bList)
            {
                count++;
                displayGrid.Items.Add(item);
            }
            return count;
        }

        private List<business> filterByAttributes(List<business> bList, NpgsqlCommand cmd)
        {
            StringBuilder fromLine = new StringBuilder(" FROM business as b");
            StringBuilder whereLine = new StringBuilder(" WHERE");
            StringBuilder statement = new StringBuilder("Select b.bname, b.addr, b.city, b.state_, b.bStars, b.reviewCount, b.reviewRatings, b.numCheckins, b.latitude, b.longitude, b.busid");
            List<business> newbList = new List<business>();


            if (creditCardAtt.IsChecked == true)
            {
                fromLine.Append(", businessAttributes as ba1");
                whereLine.Append(" ba1.busID = b.busId and ba1.aname = 'BusinessAcceptsCreditCards' and ba1.value_ = 'True' and");
            }
            if (takeReservationAtt.IsChecked == true)
            {
                fromLine.Append(", businessAttributes as ba2");
                whereLine.Append(" ba2.busID = b.busId and ba2.aname = 'RestaurantsReservations' and ba2.value_ = 'True' and");
            }
            if (wheelchairAtt.IsChecked == true)
            {
                fromLine.Append(", businessAttributes as ba3");
                whereLine.Append(" ba3.busID = b.busId and ba3.aname = 'WheelchairAccessible' and ba3.value_ = 'True' and");
            }
            if (outdoorAtt.IsChecked == true)
            {
                fromLine.Append(", businessAttributes as ba4");
                whereLine.Append(" ba4.busID = b.busId and ba4.aname = 'OutdoorSeating' and ba4.value_ = 'True' and");
            }
            if (kidsAtt.IsChecked == true)
            {
                fromLine.Append(", businessAttributes as ba5");
                whereLine.Append(" ba5.busID = b.busId and ba5.aname = 'GoodForKids' and ba5.value_ = 'True' and");
            }
            if (groupAtt.IsChecked == true)
            {
                fromLine.Append(", businessAttributes as ba6");
                whereLine.Append(" ba6.busID = b.busId and ba6.aname = 'RestaurantsGoodForGroups' and ba6.value_ = 'True' and");
            }
            if (deliveryAtt.IsChecked == true)
            {
                fromLine.Append(", businessAttributes as ba7");
                whereLine.Append(" ba7.busID = b.busId and ba7.aname = 'RestaurantsDelivery' and ba7.value_ = 'True' and");
            }
            if (takeOutAtt.IsChecked == true)
            {
                fromLine.Append(", businessAttributes as ba8");
                whereLine.Append(" ba8.busID = b.busId and ba8.aname = 'RestaurantsTakeOut' and ba8.value_ = 'True' and");
            }
            if (wifiAtt.IsChecked == true)
            {
                fromLine.Append(", businessAttributes as ba9");
                whereLine.Append(" ba9.busID = b.busId and ba9.aname = 'WiFi' and ba9.value_ = 'True' and");
            }
            if (bikeAtt.IsChecked == true)
            {
                fromLine.Append(", businessAttributes as ba10");
                whereLine.Append(" ba10.busID = b.busId and ba10.aname = 'BikeParking' and ba10.value_ = 'True' and");
            }

            if (whereLine.ToString() == " WHERE")
            {
                newbList = bList;
            }

            else
            {
                whereLine.Remove(whereLine.Length - 4, 4);
                whereLine.Append(";");
                statement.Append(fromLine);
                statement.Append(whereLine);
                cmd.CommandText = statement.ToString();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        calDistance = Math.Round(DistanceTo(reader.GetDouble(8), reader.GetDouble(9), Convert.ToDouble(latitudeTextBox.Text), Convert.ToDouble(longitudeTextBox.Text)), 2);

                        business temp = new business()
                        {
                            name = reader.GetString(0),
                            address = reader.GetString(1),
                            city = reader.GetString(2),
                            state = reader.GetString(3),
                            Stars = reader.GetDouble(4),
                            reviewCount = reader.GetInt32(5),
                            reviewRating = Math.Round(reader.GetDouble(6),2),
                            numCheckins = reader.GetInt32(7),
                            distance = calDistance,
                            busID = reader.GetString(10)
                        };

                        //checks to see if the business is part of the already filtered list. Filtered using the other filters (categories, zip code ...etc).
                        foreach (business b in bList)
                        {
                            if (b.busID == temp.busID)
                            {
                                newbList.Add(temp);
                            }
                        }
                    }
                }
            }

            return newbList;
        }

        private List<business> filterByPriceLevel(List<business> bList, NpgsqlCommand cmd)
        {
            StringBuilder fromLine = new StringBuilder(" FROM business as b");
            StringBuilder whereLine = new StringBuilder(" WHERE");
            StringBuilder statement = new StringBuilder("Select b.bname, b.addr, b.city, b.state_, b.bStars, b.reviewCount, b.reviewRatings, b.numCheckins, b.latitude, b.longitude, b.busid");
            List<business> newbList = new List<business>();

            fromLine.Append(", businessAttributes as ba1");
            if (lessThan10.IsChecked == true)
            {
                whereLine.Append(" ba1.busID = b.busId and ba1.aname = 'RestaurantsPriceRange2' and ba1.value_ = '1' or");
            }
            if (lessThan100.IsChecked == true)
            {
                whereLine.Append(" ba1.busID = b.busId and ba1.aname = 'RestaurantsPriceRange2' and ba1.value_ = '2' or");
            }
            if (lessThan1000.IsChecked == true)
            {
                whereLine.Append(" ba1.busID = b.busId and ba1.aname = 'RestaurantsPriceRange2' and ba1.value_ = '3' or");
            }
            if (lessThan10000.IsChecked == true)
            {
                whereLine.Append(" ba1.busID = b.busId and ba1.aname = 'RestaurantsPriceRange2' and ba1.value_ = '4' or");
            }


            if (whereLine.ToString() == " WHERE")
            {
                newbList = bList;
            }
            else
            {
                whereLine.Remove(whereLine.Length - 2, 2);
                whereLine.Append(";");
                statement.Append(fromLine);
                statement.Append(whereLine);
                cmd.CommandText = statement.ToString();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        calDistance = Math.Round(DistanceTo(reader.GetDouble(8), reader.GetDouble(9), Convert.ToDouble(latitudeTextBox.Text), Convert.ToDouble(longitudeTextBox.Text)), 2);

                        business temp = new business()
                        {
                            name = reader.GetString(0),
                            address = reader.GetString(1),
                            city = reader.GetString(2),
                            state = reader.GetString(3),
                            Stars = reader.GetDouble(4),
                            reviewCount = reader.GetInt32(5),
                            reviewRating = Math.Round(reader.GetDouble(6), 2),
                            numCheckins = reader.GetInt32(7),
                            distance = calDistance,
                            busID = reader.GetString(10)
                        };

                        //checks to see if the business is part of the already filtered list. Filtered using the other filters (categories, zip code ...etc).
                        foreach (business b in bList)
                        {
                            if (b.busID == temp.busID)
                            {
                                newbList.Add(temp);
                            }
                        }
                    }
                }
            }

            return newbList;
        }

        private List<business> filterByMeals(List<business> bList, NpgsqlCommand cmd)
        {
            StringBuilder fromLine = new StringBuilder(" FROM business as b");
            StringBuilder whereLine = new StringBuilder(" WHERE");
            StringBuilder statement = new StringBuilder("Select b.bname, b.addr, b.city, b.state_, b.bStars, b.reviewCount, b.reviewRatings, b.numCheckins, b.latitude, b.longitude, b.busid");
            List<business> newbList = new List<business>();


            if (Breakfast.IsChecked == true)
            {
                fromLine.Append(", businessAttributes as ba1");
                whereLine.Append(" ba1.busID = b.busId and ba1.aname = 'breakfast' and ba1.value_ = 'True' and");
            }
            if (Lunch.IsChecked == true)
            {
                fromLine.Append(", businessAttributes as ba2");
                whereLine.Append(" ba2.busID = b.busId and ba2.aname = 'lunch' and ba2.value_ = 'True' and");
            }
            if (Dinner.IsChecked == true)
            {
                fromLine.Append(", businessAttributes as ba3");
                whereLine.Append(" ba3.busID = b.busId and ba3.aname = 'dinner' and ba3.value_ = 'True' and");
            }
            if (Dessert.IsChecked == true)
            {
                fromLine.Append(", businessAttributes as ba4");
                whereLine.Append(" ba4.busID = b.busId and ba4.aname = 'dessert' and ba4.value_ = 'True' and");
            }
            if (Brunch.IsChecked == true)
            {
                fromLine.Append(", businessAttributes as ba5");
                whereLine.Append(" ba5.busID = b.busId and ba5.aname = 'brunch' and ba5.value_ = 'True' and");
            }
            if (LateNight.IsChecked == true)
            {
                fromLine.Append(", businessAttributes as ba6");
                whereLine.Append(" ba6.busID = b.busId and ba6.aname = 'latenight' and ba6.value_ = 'True' and");
            }

            if (whereLine.ToString() == " WHERE")
            {
                newbList = bList;
            }
            else
            {
                whereLine.Remove(whereLine.Length - 4, 4);
                whereLine.Append(";");
                statement.Append(fromLine);
                statement.Append(whereLine);
                cmd.CommandText = statement.ToString();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        calDistance = Math.Round(DistanceTo(reader.GetDouble(8), reader.GetDouble(9), Convert.ToDouble(latitudeTextBox.Text), Convert.ToDouble(longitudeTextBox.Text)), 2);

                        business temp = new business()
                        {
                            name = reader.GetString(0),
                            address = reader.GetString(1),
                            city = reader.GetString(2),
                            state = reader.GetString(3),
                            Stars = reader.GetDouble(4),
                            reviewCount = reader.GetInt32(5),
                            reviewRating = Math.Round(reader.GetDouble(6), 2),
                            numCheckins = reader.GetInt32(7),
                            distance = calDistance,
                            busID = reader.GetString(10)
                        };

                        //checks to see if the business is part of the already filtered list. Filtered using the other filters (categories, zip code ...etc).
                        foreach (business b in bList)
                        {
                            if (b.busID == temp.busID)
                            {
                                newbList.Add(temp);
                            }
                        }
                    }
                }
            }

            return newbList;
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

        private void setLocationButton_Click(object sender, RoutedEventArgs e)
        {
                       
        }

        public double DistanceTo(double lat1, double lon1, double lat2, double lon2, char unit = 'M')
        {
            double rlat1 = Math.PI * lat1 / 180;
            double rlat2 = Math.PI * lat2 / 180;
            double theta = lon1 - lon2;
            double rtheta = Math.PI * theta / 180;
            double dist = Math.Sin(rlat1) * Math.Sin(rlat2) + Math.Cos(rlat1) * Math.Cos(rlat2) * Math.Cos(rtheta);
            dist = Math.Acos(dist);
            dist = dist * 180 / Math.PI;
            dist = dist * 60 * 1.1515;

            switch (unit)
            {
                case 'K': //Kilometers -> default
                    return dist * 1.609344;
                case 'N': //Nautical Miles 
                    return dist * 0.8684;
                case 'M': //Miles
                    return dist;
            }

            return dist;
        }

        private void showReviewButton_Click(object sender, RoutedEventArgs e)
        {

            reviewWindow reviewWin = new reviewWindow();
            var busid = brow_info.busID;

            try
            {
                using (var connection = new NpgsqlConnection(connectionString()))
                {
                    connection.Open();
                    using (var cmd = new NpgsqlCommand())
                    {
                        cmd.Connection = connection;
                        cmd.CommandText = "SELECT r.date_, u.uname, r.stars, r.text, r.funny, r.useful, r.cool" +
                                          " FROM reviewTable as r, business as b, userTable as u" +
                                          " WHERE r.busID = b.busID AND r.userID = u.userID AND r.busID='" + busid + "';";
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                reviewWin.businessReviewGrid.Items.Add(new BusinessReview()
                                {
                                    date = reader.GetDate(0).ToString(),
                                    Uname = reader.GetString(1),
                                    stars = reader.GetDouble(2),
                                    text = reader.GetString(3),
                                    funny = reader.GetDouble(4),
                                    useful = reader.GetDouble(5),
                                    cool = reader.GetDouble(6)
                                });
                            }
                        }
                    }
                    connection.Close();
                }
            }
            catch (NullReferenceException) { }

            reviewWin.Show();
        }

        private void displayGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            checkinButton.IsEnabled = true;
            showReviewButton.IsEnabled = true;
            try
            {
                brow_info = (business)displayGrid.SelectedItem;
            }
            catch { }
        }

        private void numOfBusinessButton_Click(object sender, RoutedEventArgs e)
        {
            NumberBusiness businessNumberWindow = new NumberBusiness();
            List<KeyValuePair<int, int>> businessData = new List<KeyValuePair<int, int>>();
            try
            {
                using (var connection = new NpgsqlConnection(connectionString()))
                {
                    connection.Open();
                    using (var cmd = new NpgsqlCommand())
                    {
                        cmd.Connection = connection;

                        /*SELECT COUNT(bname)
                            FROM business
                            WHERE state_ = 'AZ' AND city = 'Chandler'
                            GROUP BY postalCode*/

                        cmd.CommandText = "SELECT postalcode, COUNT(bname)" +
                        " FROM business" +
                        " WHERE state_ = '" + stateComboBox.SelectedItem.ToString() + "' AND city = '" + cityListBox.SelectedItem.ToString() + "'" +
                        " GROUP BY postalCode";
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                KeyValuePair<int, int> data = new KeyValuePair<int, int>(reader.GetInt32(0), reader.GetInt32(1));
                               
                                businessData.Add(data);
                            }
                        }
                    }
                    connection.Close();
                }
            }
            catch (NullReferenceException) { }
            businessNumberWindow.businessNumber.DataContext = businessData;
            businessNumberWindow.Show();
            
        }

        private void showCheckinButton_Click(object sender, RoutedEventArgs e)
        {
            CheckinChart checkinWindow = new CheckinChart();
            List<KeyValuePair<String, int>> checkinData = new List<KeyValuePair<String, int>>();
            var busid = brow_info.busID;

            try
            {
                using (var connection = new NpgsqlConnection(connectionString()))
                {
                    connection.Open();
                    using (var cmd = new NpgsqlCommand())
                    {
                        cmd.Connection = connection;

                        cmd.CommandText = "SELECT dayOfWeek, (morning + afternoon + evening + night)" +
                        " FROM checkin" +
                        " WHERE busID = '" + busid + "'" +
                        " ORDER BY dayOfWeek";
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                KeyValuePair<String, int> data = new KeyValuePair<String, int>(reader.GetString(0).ToString(), reader.GetInt32(1));

                                checkinData.Add(data);
                            }
                        }
                    }
                    connection.Close();
                }
            }
            catch (NullReferenceException) { }

            checkinWindow.checkinBarChart.DataContext = checkinData;
            checkinWindow.Show();
        }

        private void sortByComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var index = displayGrid.Columns.Single(c => c.Header.ToString() == sortByComboBox.SelectedItem.ToString()).DisplayIndex;
            var performSortMethod = typeof(DataGrid).GetMethod("PerformSort", BindingFlags.Instance | BindingFlags.NonPublic);

            performSortMethod?.Invoke(displayGrid, new[] { displayGrid.Columns[index] });
        }
    }
}


