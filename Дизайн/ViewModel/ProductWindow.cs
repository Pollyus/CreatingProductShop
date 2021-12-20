using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAL.Interfaces;
using System.ComponentModel;
using BBL.Interfaces;

namespace Mustorg.ViewModel
{
    public class ProductWindowViewModel : INotifyPropertyChanged
    {
        private readonly IDbCrud _crud;
        private readonly ICategoryService _categoryService;
        private readonly IProductCatalogService _catalogService;
        public ProductWindowViewModel(int productId, IDbCrud dbCrud, ICategoryService categoryService, IProductCatalogService productCatalogService)
        {
            _crud = dbCrud;
            _categoryService = categoryService;
            _catalogService = productCatalogService;

            var Product = _crud.GetAllProducts().Where(i => i.Id == productId).ToList();
            //Amount = Product[0].Amount;
            //Article = Product[0].Article;
            //Guarantee = Product[0].Guarantee;
            //Description = Product[0].Description;
            Name = Product[0].Name;
            Photo = Product[0].Photo;
            Price = Product[0].Cost;
            //Sale = Product[0].Sale;

            //if (Product[0].Availability == true)
            //{
            //    Availability = "Есть в наличии";
            //}
            //else
            //{
            //    Availability = "Нет в наличии";
            //}
        }

        //public int Amount { get; set; }
        //public int Article { get; set; }
        //public string Guarantee { get; set; }
        //public string Description { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
        public decimal? Price { get; set; }
        public decimal? Sale { get; set; }
        public string Availability { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
