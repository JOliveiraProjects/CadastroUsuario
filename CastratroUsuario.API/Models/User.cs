using System.Collections.Generic;

namespace CadastroUsuario.API.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }

        public static implicit operator ViewModel.UserModel(User model)
        {
            return new ViewModel.UserModel
            {
                Address = model.Address,
                Age = model.Age,
                Id = model.Id,
                Name = model.Name
            };
        }

        public User()
        {
            Id = 0;
        }
    }
}
