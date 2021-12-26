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
    public class SalesViewModel : INotifyPropertyChanged
    {
        private readonly IDbCrud _crud;
        private readonly ICategoryService _categoryService;
        private readonly ICatalogService _catalogService;
        private readonly IDialogService _dialogService;
        private readonly IProfileService _profileService;
        private readonly int _userId;

        public SalesViewModel(IDbCrud dbCrud, ICategoryService categoryService, ICatalogService productCatalogService, IDialogService dialogService, IProfileService profileService, int userId)
        {
            _crud = dbCrud;
            _categoryService = categoryService;
            _catalogService = productCatalogService;
            _dialogService = dialogService;
            _profileService = profileService;
            _userId = userId;

            //Sales = new ObservableCollection<SaleModel>();
            //var result = _profileService.GetSale(_userId, 100);
            //foreach (var i in result)
            //{
            //    i.ViewText = $"Скидка {i.Offer:0.#} руб. \nПри покупке от {i.Condition:0.#} руб. ";
            //    Sales.Add(i);
            //}
            Update(0);
        }
        public void Update(int nullable)
        {
            Sales = new ObservableCollection<SaleModel>();
            var result = _profileService.GetSale(_userId, 1000);
            foreach (var i in result)
            {
                i.ViewText = $"Скидка {i.Offer:0.#} руб. \nПри покупке от {i.Condition:0.#} руб. ";
                Sales.Add(i);
            }
        }
        public ObservableCollection<SaleModel> Sales
        {
            get
            {
                return _Sales;
            }
            set
            {
                _Sales = value;
                NotifyPropertyChanged("Sales");
            }
        }
        private ObservableCollection<SaleModel> _Sales;

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
