using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using BAL;
using BAL.Interfaces;
using BBL.Interfaces;
using View.Util;
using Ninject;
using Дизайн.ViewModel;
using Дизайн.View;
using BAL.Util;

namespace Дизайн
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void OnStartup(object sender, StartupEventArgs e)
        {
            var kernel = new StandardKernel(new NinjectRegistration(), new ServiceModule());

            IDbCrud crudServ = kernel.Get<IDbCrud>();
            ICategoryService catServ = kernel.Get<ICategoryService>();
            ICatalogService prodCatServ = kernel.Get<ICatalogService>();
            IOrderService ordServ = kernel.Get<IOrderService>();
            IProfileService profServ = kernel.Get<IProfileService>();

            LoginWindow loginWindow = new LoginWindow(crudServ, catServ, prodCatServ, ordServ, profServ);

            loginWindow.Show();


        }
    }
}
