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
using View.ViewModel;

namespace Дизайн.View
{
    /// <summary>
    /// Логика взаимодействия для MainWindow .xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(IDbCrud crudService, ICategoryService categoryService, ICatalogService productCatalogService, IOrderService orderService, IProfileService profileService, int userId, IFileService fileService)
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel(crudService, categoryService, productCatalogService, orderService, new DialogService(), profileService, userId, fileService);
        }

        private void CatalogControlWindow_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
    
}
