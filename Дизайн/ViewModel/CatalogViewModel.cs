using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAL.Interfaces;
using System.ComponentModel;
using BAL.Models;
using View.Util;
using System.Collections.ObjectModel;
using System.Windows.Input;
using BAL.Servises;
using BBL.Interfaces;
using Дизайн.ViewModel;
using View;
using Дизайн;
using View.ViewModel;
using BBL.Models;
using GalaSoft.MvvmLight.Messaging;


namespace Дизайн.ViewModel
{
    public class CatalogViewModel : INotifyPropertyChanged
    {
        private readonly IDbCrud _crud;
        private readonly ICategoryService _categoryService;

        private readonly IDialogService _dialogService;
        //private readonly IOrderService _orderService;
        //private readonly IProfileService _profileService;
        private readonly ICatalogService _catalogService;
        private readonly int _userId;
        public CatalogViewModel(IDbCrud dbCrud, ICategoryService categoryService, ICatalogService productCatalogService, IDialogService dialogService, int userId)
        {
            _crud = dbCrud;
            _categoryService = categoryService;
            _catalogService = productCatalogService;
            _dialogService = dialogService;
            _userId = userId;

            string date = "12/31/2020";
            var tempTypes = _categoryService.GetTypeModels();
            Types = new ObservableCollection<CategoryTypeModel>();
            foreach (var i in tempTypes)
            {
                Types.Add(i);
            }

            var tempProd = _crud.GetAllProducts();
            _Products = new ObservableCollection<ProductModel>();
            foreach (var i in tempProd)
            {
                i.ViewPrice = $"{i.Cost:0.#} руб.";
                
                _Products.Add(i);
            }
        }

        #region Выбор элемента в дереве
        private string _selectedCategory;

        private ICommand _selectedItemChangedCommand;
        public ICommand SelectedItemChangedCommand
        {
            get
            {
                if (_selectedItemChangedCommand == null)
                    _selectedItemChangedCommand = new RelayCommand(args => SelectedItemChanged(args));
                return _selectedItemChangedCommand;
            }
        }

        private void SelectedItemChanged(object args)
        {
            _selectedCategory = args.ToString();
            Products = new ObservableCollection<ProductModel>();
            var tempProd = _catalogService.GetProductsByCategory(_selectedCategory);
            foreach (var i in tempProd)
            {
                i.ViewPrice = $"{i.Cost:0.#} руб.";
                Products.Add(i);
            }
        }
        #endregion


        #region Выбор товара
        private ICommand _selectedIndexCommand;
        public ICommand SelectedIndexChangedCommand
        {
            get
            {
                if (_selectedIndexCommand == null)
                    _selectedIndexCommand = new RelayCommand(args => SelectedIndexChanged(args));
                return _selectedIndexCommand;
            }
        }

        
        #endregion
        private void SelectedIndexChanged(object args)
        {
            
            if ((int)args != -1)
            {
                productId = Products[(int)args].Id;
                

                var Product = _crud.GetAllProducts().Where(i => i.Id == productId).ToList();
                
                Description = "Описание: \n" + Product[0].Description;
                Name = Product[0].Name;
                Photo = Product[0].Photo;
                Price = $"Стоимость: {Product[0].Cost:0.#} руб.";
                CanAddToCart = Product[0].Avalibility;
                DateProduction = Product[0].DateProduction.ToString();
                DateExpiration = Product[0].DateExpiration.ToString();

                if (Product[0].Sale != null)
                {
                    Sale = $"Скидка: {Product[0].Sale:0.#} руб.";
                }

                if (Product[0].Avalibility == true)
                {
                    Availability = " Есть в наличии";
                }
                else
                {
                    Availability = " Нет в наличии";
                }
            }
        }
        private int productId; 
        
        public string DateProduction
        {
            get
            {
                return _DateProduction;
            }
            set
            {
                _DateProduction = value;
                NotifyPropertyChanged("DateProduction");
            }
        }
        private string _DateProduction;

        public string DateExpiration
        {
            get
            {
                return _DateExpiration;
            }
            set
            {
                _DateExpiration = value;
                NotifyPropertyChanged("DateExpiration");
            }
        }
        private string _DateExpiration;

        public string Description
        {
            get
            {
                return _Description;
            }
            set
            {
                _Description = value;
                NotifyPropertyChanged("Description");
            }
        }
        private string _Description;
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
                NotifyPropertyChanged("Name");
            }
        }
        private string _Name;
        public string Photo
        {
            get
            {
                return _Photo;
            }
            set
            {
                _Photo = value;
                NotifyPropertyChanged("Photo");
            }
        }
        private string _Photo;
        public string Price
        {
            get
            {
                return _Price;
            }
            set
            {
                _Price = value;
                NotifyPropertyChanged("Price");
            }
        }
        private string _Price;
        public string Sale
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
        private string _Sale;
        public string Availability
        {
            get
            {
                return _Availability;
            }
            set
            {
                _Availability = value;
                NotifyPropertyChanged("Availability");
            }
        }
        private string _Availability;

        #region Добавить в корзину
        public bool CanAddToCart
        {
            get
            {
                return _CanAddToCart;
            }
            set
            {
                _CanAddToCart = value;
                NotifyPropertyChanged("CanAddToCart");
            }
        }
        private bool _CanAddToCart;



        private ICommand _addToCart;
        public ICommand AddToCart
        {
            get
            {
                if (_addToCart == null)
                    _addToCart = new RelayCommand(args => UpdateCart(args));
                return _addToCart;
            }
        }

        private void UpdateCart(object args)
        {
            CartModel cart = new CartModel();
            cart.ProductId = productId;
            cart.BuyerId = _userId;
            _crud.CreateCart(cart);
            Messenger.Default.Send(new GenericMessage<CartModel>(null));
        }
        #endregion
       
        public ObservableCollection<CategoryTypeModel> Types { get; set; }

        public ObservableCollection<ProductModel> Products
        {
            get
            {
                return _Products;
            }
            set
            {
                _Products = value;
                NotifyPropertyChanged("Products");
            }
        }
        private ObservableCollection<ProductModel> _Products;

        

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Update(int productId)
        {
            if (productId != -1 && productId != 0)
            {
                IsVisible = "Visible";
                this.productId = productId;

                var Product = _crud.GetAllProducts().Where(i => i.Id == this.productId).ToList();
                Description = "Описание: \n" + Product[0].Description;
                Name = Product[0].Name;
                Photo = Product[0].Photo;
                Price = $"Стоимость: {Product[0].Cost:0.#} руб.";
                CanAddToCart = Product[0].Avalibility;
                DateExpiration = Product[0].DateExpiration.ToString();
                DateProduction = Product[0].DateProduction.ToString();

                if (Product[0].Sale != null)
                {
                    Sale = $"Скидка: {Product[0].Sale:0.#} руб.";
                }
                else
                {
                    Sale = "";
                }

                if (Product[0].Avalibility == true)
                {
                    Availability = " Есть в наличии";
                }
                else
                {
                    Availability = " Нет в наличии";
                }
            }
            else if (this.productId != -1 && productId == 0)
            {
                var Product = _crud.GetAllProducts().Where(i => i.Id == this.productId).ToList();
                CanAddToCart = Product[0].Avalibility;

                if (Product[0].Avalibility == true)
                {
                    Availability = " Есть в наличии";
                }
                else
                {
                    Availability = " Нет в наличии";
                }
            }
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

    }
}

