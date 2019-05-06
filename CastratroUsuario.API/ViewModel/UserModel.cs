using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CadastroUsuario.API.ViewModel
{
    public class UserModel : IValidatableObject
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public int Age { get; set; }

        [StringLength(50)]
        public string Address { get; set; }

        public static implicit operator Models.User(UserModel model)
        {
            return new Models.User
            {
                Address = model.Address,
                Age = model.Age,
                Id = model.Id,
                Name = model.Name
            };
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validations = new List<ValidationResult>();

            if (string.IsNullOrEmpty(Name))
            {
                validations.Add(new ValidationResult("O nome é obrigatório."));
            }

            if (string.IsNullOrEmpty(Address) || Address.Length > 50 || Address.Length <= 0)
            {
                validations.Add(new ValidationResult("O endereço é obrigatório."));
            }
            else if (Address.Length > 50 || Address.Length <= 0)
            { 
                validations.Add(new ValidationResult("O endereço é obrigatório."));
            }

            if (Age > 120 || Age <= 10)
            {
                validations.Add(new ValidationResult("Idade não permitida para se cadastrar."));
            }

            return validations;
        }
    }
}
