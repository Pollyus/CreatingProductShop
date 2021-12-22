using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAL.Interfaces;
using BAL.Models;
using DAL.Interfaces;
using BBL.Interfaces;
using DAL;

namespace BBL.Servises
{
    public class CategoryService : ICategoryService
    {
        IDbRepos dataBase;
        public CategoryService(IDbRepos dbRepository)
        {
            dataBase = dbRepository;
        }

        public List<CategoryTypeModel> GetTypeModels()
        {
            var Types = dataBase.CategoryTypes.GetList().Select(i => new CategoryTypeModel { Id = i.Id, Name = i.Name }).ToList();
            foreach (var type in Types)
            {
                var categories = dataBase.Categories.GetList().Where(i => i.TypeId == type.Id).Select(i => new CategoryModel { Id = i.Id, Name = i.CategoryName }).ToList();
                type.Categories = new System.Collections.ObjectModel.ObservableCollection<CategoryModel>();
                foreach (var cat in categories)
                {
                    type.Categories.Add(cat);
                }
            }
            return Types;
        }
    }
}
