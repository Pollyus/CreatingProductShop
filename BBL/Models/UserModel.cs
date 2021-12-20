using System;
using DAL.Entities;

namespace BLL.Models
{
    public class UserModel
    {
        public UserModel() { }

        public UserModel(User user)
        {
            Name = user.Name;
            Login = user.Login;
            Password = user.Password;
            TipeID = user.TipeID;
            //Email = user.Email;
            //Sum = user.Sum;
           /// user_Status_Id = user.user_Status_Id;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public decimal? Sum { get; set; }
        public int TipeID { get; set; }
        ///public int user_Status_Id { get; set; }
    }
}