//using Дизайн.DB;
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
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;


namespace Дизайн
{
    /// <summary>
    /// Логика взаимодействия для CatalogView.xaml
    /// </summary>
    public partial class CatalogView : Window
    {       
       
        public CatalogView()
        {
            InitializeComponent();
             Model1 ProductCatalog = new Model1();
                //BindingList<Product> allProduct;
            List<Product> products = ProductCatalog.Products.ToList();

            ListCatalogView.ItemsSource = products;
        }
     


        private void MainWindowReturn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Hide();
        }

        private void BusketButton_Click(object sender, RoutedEventArgs e)
        {
            Busket busket = new Busket();
            busket.Show();
            this.Hide();

            //ToolTip t = new ToolTip();
            //t.SetToolTip(button82, "Выход");
        }

        private void UserPageButton_Click(object sender, RoutedEventArgs e)
        {
            UserPageWindow userPageWindow = new UserPageWindow();
            userPageWindow.Show();
            this.Hide();
        }
    }
}
