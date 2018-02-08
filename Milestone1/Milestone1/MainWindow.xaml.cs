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
        public string name { get; set; }
        public string state { get; set; }
        public string city { get; set; }
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
            return "Host=localhost; Username=postgres; Password=Khan1992; Database=Milestone1DB";
        }

        public void addStates()
        {
            using (var connection = new NpgsqlConnection(connectionString()))
            {
                connection.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = "SELECT distinct state FROM business ORDER BY state;";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while(reader.Read())
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
            DataGridTextColumn businessCol = new DataGridTextColumn();
            businessCol.Header = "Business Name";
            businessCol.Binding = new Binding("name");
            businessCol.Width = 255;
            businessDataGrid.Columns.Add(businessCol);

            DataGridTextColumn stateCol = new DataGridTextColumn();
            stateCol.Header = "State";
            stateCol.Binding = new Binding("city");
            businessDataGrid.Columns.Add(stateCol);

            DataGridTextColumn cityCol = new DataGridTextColumn();
            cityCol.Header = "City";
            cityCol.Binding = new Binding("state");
            businessDataGrid.Columns.Add(cityCol);
        }

        private void stateComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            using (var connection = new NpgsqlConnection(connectionString()))
            {
                connection.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = "SELECT DISTINCT city FROM business WHERE state = '" + stateComboBox.SelectedItem.ToString() + "' ORDER BY city;";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cityComboBox.Items.Add(reader.GetString(0).ToString());
                        }
                    }
                }
                connection.Close();
            }
        }

        private void cityComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            businessDataGrid.Items.Clear();
            using (var connection = new NpgsqlConnection(connectionString()))
            {
                connection.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = "SELECT name,city,state FROM business WHERE city = '" +
                        cityComboBox.SelectedItem.ToString() + "' AND state = '" + stateComboBox.SelectedItem.ToString() + "'; ";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            businessDataGrid.Items.Add(new business()
                            {
                                name = reader.GetString(0),
                                city = reader.GetString(1),
                                state = reader.GetString(2)
                            });
                        }
                    }
                }
                connection.Close();
            }
        }
    }
}
