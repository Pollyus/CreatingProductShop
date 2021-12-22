using DAL.Entities;

namespace BLL.Models
{
    public class TypeOfPaymentModel
    {
        public TypeOfPaymentModel() { }

        public TypeOfPaymentModel(TypeOfPayment typeOfPayment)
        {
            Id = typeOfPayment.Id;
            Name = typeOfPayment.Name;
        }

        public int Id { get; set; }

        public string Name { get; set; }
    }
}
