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

namespace Milestone1
{
    /// <summary>
    /// Interaction logic for reviewWindow.xaml
    /// </summary>
    public partial class reviewWindow : Window
    {
        public reviewWindow()
        {
            InitializeComponent();
            addColumns();
        }

        public void addColumns()
        {
            DataGridTextColumn dateCol = new DataGridTextColumn();
            dateCol.Header = "Date";
            dateCol.Binding = new Binding("date");
            businessReviewGrid.Columns.Add(dateCol);

            DataGridTextColumn bnameCol = new DataGridTextColumn();
            bnameCol.Header = "User";
            bnameCol.Binding = new Binding("Uname");
            businessReviewGrid.Columns.Add(bnameCol);

            DataGridTextColumn starsCol = new DataGridTextColumn();
            starsCol.Header = "Stars";
            starsCol.Binding = new Binding("stars");
            businessReviewGrid.Columns.Add(starsCol);

            DataGridTextColumn textCol = new DataGridTextColumn();
            textCol.Header = "Text";
            textCol.Width = 250;
            textCol.Binding = new Binding("text");
            businessReviewGrid.Columns.Add(textCol);

            DataGridTextColumn funnyCol = new DataGridTextColumn();
            funnyCol.Header = "Funny";
            funnyCol.Binding = new Binding("funny");
            businessReviewGrid.Columns.Add(funnyCol);

            DataGridTextColumn usefulCol = new DataGridTextColumn();
            usefulCol.Header = "Useful";
            usefulCol.Binding = new Binding("useful");
            businessReviewGrid.Columns.Add(usefulCol);

            DataGridTextColumn coolCol = new DataGridTextColumn();
            coolCol.Header = "Cool";
            coolCol.Binding = new Binding("cool");
            businessReviewGrid.Columns.Add(coolCol);
        }


    }
}
