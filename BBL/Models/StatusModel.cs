using DAL.Entities;


namespace BLL.Models
{
    public class StatusModel
    {
        public StatusModel() { }

        public StatusModel(OrderStatus status)
        {
            Id = status.Id;
            Name = status.Name;
        }
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
