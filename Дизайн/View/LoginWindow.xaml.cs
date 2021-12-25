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
using Дизайн.ViewModel;
using BAL.Interfaces;
using Дизайн.Util;
using BBL.Interfaces;
using View.ViewModel;

namespace Дизайн
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow(IDbCrud crudService, ICategoryService categoryService, ICatalogService productCatalogService, IOrderService orderService, IProfileService profileService, IFileService fileService)
        {
            InitializeComponent();

            AuthViewModel viewModel = new AuthViewModel(crudService, categoryService, productCatalogService, orderService, new DialogService(), profileService, fileService);

            DataContext = viewModel;
            viewModel.Notify += CloseWindow;

        }

        void CloseWindow()
        {
            this.Close();
        }
    }
}
