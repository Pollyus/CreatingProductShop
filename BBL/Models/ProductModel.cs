using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Entities;
using System.ComponentModel;

namespace BAL.Models
{
    public class ProductModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal? Cost { get; set; }

        public int? CategoryId { get; set; }
        public string Photo { get; set; }
        public decimal? Sale { get; set; }
        public string Description { get; set; }
        public DateTime? DateProduction { get; set; }
        public DateTime? DateExpiration { get; set; }
        public int? Amount{ get; set; }
        public string ViewPrice { get; set; }
        public bool Avalibility { get; set; }

        public int? BrandId { get; set; }
        public ProductModel() { }
        public ProductModel(Product product)
        {
            Id = product.Id;
            Name = product.Name;
            Cost = product.Cost;
            CategoryId = product.CategoryId;
            Sale = product.Sale;
            Photo = product.Photo;
            Description = product.Description;
            Avalibility = product.Avalibility;
            DateExpiration = product.DateExpiration;
            DateProduction = product.DateProduction;
            Amount = product.Amount;
            Sale = product.Sale;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
