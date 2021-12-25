using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BBL.Interfaces;
using BBL.Servises;
using BAL.Interfaces;
using BAL.Models;

namespace View.Util
{
    public interface IDialogService
    {
        void OpenCatalogWindow(IDbCrud dbCrud, ICategoryService categoryService, ICatalogService productCatalogService, IOrderService orderService, IDialogService dialogService, IProfileService profileService, int UserId, IFileService fileService);
    }
}
