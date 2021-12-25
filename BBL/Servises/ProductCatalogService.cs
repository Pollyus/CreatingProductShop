using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAL.Models;
using BAL.Interfaces;
using DAL.Interfaces;
using BBL.Interfaces;


namespace BBL.Servises
{
    public class ProductCatalogService : ICatalogService
    {
        IDbRepos dataBase;
        public ProductCatalogService(IDbRepos dbRepository)
        {
            dataBase = dbRepository;
        }

        public List<ProductModel> GetProductsByCategory(string category)
        {
            return dataBase.Services.GetProductsByCategory(category).Select(i => new ProductModel { Id = i.Id, Photo = i.Photo, Name = i.Name, Cost= i.Cost, Sale = i.Sale }).ToList(); 
        }
    }
}
