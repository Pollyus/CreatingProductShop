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

        public decimal Cost { get; set; }

        public int? CategoryId { get; set; }
        public string Photo { get; set; }
        public decimal? Sale { get; set; }
        public ProductModel() { }
        public ProductModel(Product product)
        {
            Id = product.Id;
            Name = product.Name;
            Cost = product.Cost;
            CategoryId = product.CategoryId;
            //Sale = product.Sale;
            Photo = product.Photo;
            
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
