using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using BAL.Interfaces;
using BBL.Interfaces;
using BLL.Models;
using BAL.Models;
using Дизайн.Util;
using View.Util;
using System.Collections.ObjectModel;
using System.Windows.Input;
using View.ViewModel;
using Дизайн.ViewModel;

namespace View.ViewModel
{
    public class ProfileViewModel : INotifyPropertyChanged
    {
        private readonly IDbCrud _crud;
        private readonly ICategoryService _categoryService;
        private readonly ICatalogService _catalogService;
        private readonly IDialogService _dialogService;
        private readonly IProfileService _profileService;
        private readonly int _userId;

        public ProfileViewModel(IDbCrud dbCrud, ICategoryService categoryService, ICatalogService productCatalogService, IDialogService dialogService, IProfileService profileService, int userId)
        {
            _crud = dbCrud;
            _categoryService = categoryService;
            _catalogService = productCatalogService;
            _dialogService = dialogService;
            _profileService = profileService;
            _userId = userId;

            ProfileVM = new MyProfileViewModel(dbCrud, categoryService, productCatalogService, dialogService, profileService, userId);
            OrdersVM = new MyOrdersViewModel(dbCrud, categoryService, productCatalogService, dialogService, profileService, userId);
            StatsVM = new StatsViewModel(dbCrud, categoryService, productCatalogService, dialogService, profileService, userId);
            SalesVM = new SalesViewModel(dbCrud, categoryService, productCatalogService, dialogService, profileService, userId);
        }
        public MyProfileViewModel ProfileVM { get; set; }
       
        public MyOrdersViewModel OrdersVM { get; set; }
        public StatsViewModel StatsVM { get; set; }
        
        public SalesViewModel SalesVM { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
