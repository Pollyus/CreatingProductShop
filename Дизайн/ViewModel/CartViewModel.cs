using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAL.Interfaces;
using BBL.Interfaces;
using GalaSoft.MvvmLight.Messaging;
using View.Util;
using Дизайн.Util;
using View;
using System.Collections.ObjectModel;
using System.Windows.Input;
using BBL.Models;
using BAL.Models;

namespace Дизайн.ViewModel
{

    public class CartViewModel : INotifyPropertyChanged
    {
        private readonly IDbCrud _crud;
        private readonly ICategoryService _categoryService;
        private readonly ICatalogService _catalogService;
        private readonly IDialogService _dialogService;
        private readonly IOrderService _orderService;
        private readonly IProfileService _profileService;
        private readonly int _userId;

        public CartViewModel(IDbCrud dbCrud, ICategoryService categoryService, ICatalogService productCatalogService, IDialogService dialogService, IOrderService orderService, IProfileService profileService, int userId)
        {
            _crud = dbCrud;
            _categoryService = categoryService;
            _catalogService = productCatalogService;
            _dialogService = dialogService;
            _orderService = orderService;
            _profileService = profileService;
            _userId = userId;

            IsVisible = "Visible";
            CanMakeOrder = false;
            OrderVisibility = "Hidden";
            CodeSale = $"По данной скидке вы сэкономили: 0 руб.";
            UserAddress= "";
            UserAddress = "";
            UpdateOrderPage();
            
            Messenger.Default.Register<GenericMessage<CartModel>>(this, Update);

        }

        private ObservableCollection<CartModel> _Cart;
        public ObservableCollection<CartModel> Cart
        {
            get
            {
                return _Cart;
            }
            set
            {
                _Cart = value;
                NotifyPropertyChanged("Cart");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _IsVisible;
        public string IsVisible
        {
            get
            {
                return _IsVisible;
            }
            set
            {
                _IsVisible = value;
                NotifyPropertyChanged("IsVisible");
            }
        }

        public string Total
        {
            get
            {
                return _Total;
            }
            set
            {
                _Total = value;
                NotifyPropertyChanged("Total");
            }
        }
        private string _Total;
        private decimal? total;

        private void UpdateOrderPage()
        {
            total = 0;

            Cart = new ObservableCollection<CartModel>();
            var result = _orderService.GetShoppingCart(_userId);
            foreach (CartModel i in result)
            {
                ProductModel product = _crud.GetProduct(i.ProductId);
                if (product.Amount == i.Amount) i.PlusEnabled = false;
                else i.PlusEnabled = true;
                i.ViewPrice = $"Стоимость: {i.FullPrice:0.#} руб.";
                if (i.FullSale == null) i.FullSale = 0;
                if (i.Amount == 1) i.MinusEnabled = false;
                else i.MinusEnabled = true;
                i.ViewSale = $"Скидка: {i.FullSale:0.#} руб.";
                i.ViewTotal = $"Итого: {i.FullPrice - i.FullSale:0.#} руб.";
                Cart.Add(i);
                total += i.FullPrice - i.FullSale;
            }
            if (Cart.Count != 0)
            {
                CanMakeOrder = true;
                IsVisible = "Hidden";
            }
            else
            {
                CanMakeOrder = false;
                IsVisible = "Visible";
            }

            Sale = new ObservableCollection<SaleModel>();
            SaleModel none = new SaleModel();
            none.SaleName = "Нет";
            none.Offer = 0;
            Sale.Add(none);
            var resu = _profileService.GetSale(_userId, (decimal)total);
            foreach (var i in resu)
            {
                Sale.Add(i);
            }

            StatusSale = $"Скидка за статус: {total * 0.05m:0.##} руб.";
            Total = $"Итого: {total * 0.95m:0.##} руб.";
            CodeSale = $"Применив скидку вы сэкономили: 0 руб.";
            SelectedSale = 0;
        }


        #region Корзина
        private void Update(GenericMessage<CartModel> msg)
        {
            UpdateOrderPage();
        }

        private ICommand _deleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                if (_deleteCommand == null)
                    _deleteCommand = new RelayCommand(args => BinClicked(args));
                return _deleteCommand;
            }
        }
        private void BinClicked(object args)
        {
            _crud.DeleteCart(Cart[(int)args].Id);
            UpdateOrderPage();
        }


        private ICommand _plusAmountCommand;
        public ICommand PlusAmountCommand
        {
            get
            {
                if (_plusAmountCommand == null)
                    _plusAmountCommand = new RelayCommand(args => PlusClicked(args));
                return _plusAmountCommand;
            }
        }
        private void PlusClicked(object args)
        {
            Cart[(int)args].Amount++;
            _crud.UpdateCart(Cart[(int)args]);
            UpdateOrderPage();
        }


        private ICommand _minusAmountCommand;
        public ICommand MinusAmountCommand
        {
            get
            {
                if (_minusAmountCommand == null)
                    _minusAmountCommand = new RelayCommand(args => MinusClicked(args));
                return _minusAmountCommand;
            }
        }
        private void MinusClicked(object args)
        {
            Cart[(int)args].Amount--;
            _crud.UpdateCart(Cart[(int)args]);
            UpdateOrderPage();
        }
        #endregion

        #region Заказ
        public ICommand EndMakeOrder
        {
            get
            {
                if (_endMakeOrder == null)
                    _endMakeOrder = new RelayCommand(args => CloseMakeOrder(args));
                return _endMakeOrder;
            }
        }
        private ICommand _endMakeOrder;

        private void CloseMakeOrder(object args)
        {
            OrderVisibility = "Hidden";
            _crud.CreateBuyer(new BuyerModel
            {
                Address = this.UserAddress

            });
        }
        public ICommand MakeOrder
        {
            get
            {
                if (_makeOrder == null)
                    _makeOrder = new RelayCommand(args => OpenMakeOrder(args));
                return _makeOrder;
            }
        }
        private ICommand _makeOrder;
        private void OpenMakeOrder(object args)
        {
            OrderVisibility = "Visible";
        }

        public ICommand EndOrder
        {
            get
            {
                if (_endOrder == null)
                    _endOrder = new RelayCommand(args => MakeOrderCheck(args));
                return _endOrder;
            }
        }
        private ICommand _endOrder;
        private void MakeOrderCheck(object args)
        {

        }

        public bool CanMakeOrder
        {
            get
            {
                return _CanMakeOrder;
            }
            set
            {
                _CanMakeOrder = value;
                NotifyPropertyChanged("CanMakeOrder");
            }
        }
        private bool _CanMakeOrder;

        public string OrderVisibility
        {
            get
            {
                return _Ordervisibility;
            }
            set
            {
                _Ordervisibility = value;
                NotifyPropertyChanged("OrderVisibility");
            }
        }
        private string _Ordervisibility;

        public ICommand SelectedIndexChangedCommand
        {
            get
            {
                if (_selectedIndexChangedCommand == null)
                    _selectedIndexChangedCommand = new RelayCommand(args => ChangeIndex(args));
                return _selectedIndexChangedCommand;
            }
        }
        private ICommand _selectedIndexChangedCommand;
        private void ChangeIndex(object args)
        {
            SelectedSale = (int)args;
            CodeSale = $"Скидка составила: {Sale[SelectedSale].Offer:0.#} руб.";
            Total = $"Итого: {total * 0.95m - Sale[SelectedSale].Offer:0.##} руб.";
        }

       
        public ObservableCollection<SaleModel> Sale
        {
            get
            {
                return _Sale;
            }
            set
            {
                _Sale = value;
                NotifyPropertyChanged("Sale");
            }
        }
        private ObservableCollection<SaleModel> _Sale;

        public string StatusSale
        {
            get
            {
                return _StatusSale;
            }
            set
            {
                _StatusSale = value;
                NotifyPropertyChanged("StatusSale");
            }
        }
        private string _StatusSale;

        public string CodeSale
        {
            get
            {
                return _CodeSale;
            }
            set
            {
                _CodeSale = value;
                NotifyPropertyChanged("CodeSale");
            }
        }
        private string _CodeSale;

        public int SelectedSale
        {
            get
            {
                return _SelectedSale;
            }
            set
            {
                _SelectedSale = value;
                NotifyPropertyChanged("SelectedSale");
            }
        }
        private int _SelectedSale;
        #endregion

        private string _UserAddress;
        public string UserAddress
        {
            get
            {
                return _UserAddress;
            }
            set
            {
                _UserAddress = value;
                NotifyPropertyChanged("UserAddress");
            }
        }
       
        public string UserPhone
        {
            get
            {
                return _UserPhone;
            }
            set
            {
                _UserPhone = value;
                NotifyPropertyChanged("UserPhone");
            }
        }
        private string _UserPhone;
    }

}