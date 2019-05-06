using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CadastroUsuario.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly Data.UserData _data = new Data.UserData();

        // GET api/values
        [HttpGet]
        public IEnumerable<ViewModel.UserModel> Get(string name)
        {
            List<ViewModel.UserModel> list = new List<ViewModel.UserModel>();
            var data = _data.All(name).ToList();

            if (data.Any())
            {
                data.ForEach(x => list.Add(new ViewModel.UserModel
                {
                    Address = x.Address,
                    Age = x.Age,
                    Id = x.Id,
                    Name = x.Name
                }));
            }

            return list;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ViewModel.UserModel Get(int id)
        {
            ViewModel.UserModel resultModel = _data.Get(id);
            if (resultModel != null)
                return resultModel;

            return null;
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] ViewModel.UserModel model)
        {
            if (ModelState.IsValid)
            {
                var resultModel = _data.Add(model);
                return Ok(resultModel);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
