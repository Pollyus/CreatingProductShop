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
using View.Util;
using Дизайн.ViewModel;
using BBL.Interfaces;
using BAL.Interfaces;
using Дизайн.Util;

namespace Дизайн.View
{
    /// <summary>
    /// Логика взаимодействия для CatalogControlWindow.xaml
    /// </summary>
    public partial class CatalogControlWindow : UserControl
    {
        public CatalogControlWindow()
        {
            InitializeComponent();
            
        }

        private void listView_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (listView.SelectedIndex != -1)
            {
                this.myProductGrid.Visibility = Visibility.Visible;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            listView.SelectedIndex = -1;
            this.myProductGrid.Visibility = Visibility.Hidden;
        }
    }
    
}
