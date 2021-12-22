using DAL.Entities;

namespace BLL.Models
{
    public class BrandModel
    {
        public BrandModel() { }

        public BrandModel(Brand brand)
        {
            Id = brand.Id;
            Name = brand.Name;
        }

        public int Id { get; set; }

        public string Name { get; set; }
    }
}
