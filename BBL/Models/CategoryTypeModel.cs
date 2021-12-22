using System.Collections.ObjectModel;

namespace BAL.Models
{
    public class CategoryTypeModel
    {
        public CategoryTypeModel() { }

        public CategoryTypeModel(CategoryTypeModel type)
        {
            Id = type.Id;
            Name = type.Name;
            Categories = type.Categories;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public ObservableCollection<CategoryModel> Categories { get; set; }
    }
}