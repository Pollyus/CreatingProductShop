using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BBL.Interfaces;
using View;
using View.Util;
using BAL.Interfaces;
using Дизайн.View;

namespace Дизайн.Util
{
    class DialogService : IDialogService
    {
        public void OpenCatalogWindow(IDbCrud dbCrud, ICategoryService categoryService, ICatalogService productCatalogService, IOrderService orderService, IDialogService dialogService, IProfileService profileService, int userId)
        {
            MainWindow mainWindow = new MainWindow(dbCrud, categoryService, productCatalogService, orderService, profileService, userId);
            mainWindow.Show();
        }
    }
}
