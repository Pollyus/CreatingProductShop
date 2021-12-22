using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using BAL.Interfaces;
using BBL.Interfaces;
using BLL.Models;
using View.Util;
using System.Collections.ObjectModel;
using System.Windows.Input;
using BBL.Models;

namespace View.ViewModel
{
    public class CouponsViewModel : INotifyPropertyChanged
    {
        private readonly IDbCrud _crud;
        private readonly ICategoryService _categoryService;
        private readonly ICatalogService _catalogService;
        private readonly IDialogService _dialogService;
        private readonly IProfileService _profileService;
        private readonly int _userId;

        public CouponsViewModel(IDbCrud dbCrud, ICategoryService categoryService, ICatalogService productCatalogService, IDialogService dialogService, IProfileService profileService, int userId)
        {
            _crud = dbCrud;
            _categoryService = categoryService;
            _catalogService = productCatalogService;
            _dialogService = dialogService;
            _profileService = profileService;
            _userId = userId;

            Coupons = new ObservableCollection<SaleModel>();
            var result = _profileService.GetSale(_userId, 100);
            foreach (var i in result)
            {
                i.ViewText = $"Скидка {i.Offer:0.#} руб. \nПри покупке от {i.Condition:0.#} руб. ";
                Coupons.Add(i);
            }

        }

        public ObservableCollection<SaleModel> Coupons
        {
            get
            {
                return _Coupons;
            }
            set
            {
                _Coupons = value;
                NotifyPropertyChanged("Coupons");
            }
        }
        private ObservableCollection<SaleModel> _Coupons;

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
