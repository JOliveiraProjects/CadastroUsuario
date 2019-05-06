using System.Collections.Generic;
using System.Linq;

namespace CadastroUsuario.API.Data
{
    public class UserData
    {
        private static List<Models.User> _users = new List<Models.User>
        {
            new Models.User { Id = 1, Name = "João Batista", Age = 36, Address = "Rua A, 12" },
            new Models.User { Id = 2, Name = "Carlos Gonsalves", Age = 40, Address = "Rua A, 15" },
            new Models.User { Id = 3, Name = "Mario Yamamoto", Age = 25, Address = "Rua A, 1358" },
            new Models.User { Id = 4, Name = "Paulo Andreade", Age = 16, Address = "Rua A, 3" }
        };

        public UserData() { }

        public Models.User Add(Models.User model)
        {
            if (model.Id > 0)
            {
                Models.User resultModel = Get(model.Id);
                if (resultModel != null)
                {
                    resultModel.Name = model.Name;
                    resultModel.Age = model.Age;
                    resultModel.Address = model.Address;
                }
            }
            else
            {
                model.Id = _users.Count + 1;
                _users.Add(model);
            }

            return model;
        }

        public Models.User Get(int id)
        {
            return _users.Where(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<Models.User> All(string search)
        {
            List<Models.User> list = new List<Models.User>();
            bool isName = !string.IsNullOrEmpty(search);
            var result = _users.Where(x => (!isName || (isName && (x.Name.Contains(search))))).ToList();

            if (result.Any())
                list = result;

            return list;
        }
    }
}
 
