using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Entities;

namespace BAL.Models
{
    public class CategoryModel
    {
        public CategoryModel() { }

        public CategoryModel(Category category)
        {
            Id = category.Id;
            Name = category.CategoryName;

        }

        public int Id { get; set; }

        public string Name { get; set; }


    }
}
