using CoreMeetUp.Database;
using CoreMeetUp.DTO;
using CoreMeetUp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace CoreMeetUp.Controllers
{
    public class LoginController : ApiController
    {
        [HttpGet]
        [Route("api/login")]
        public async Task<LoginDTO[]> Get()
        {
            using (var repo = new LoginRepository())
            {
                return (await repo.GetAll()).Select(x => new LoginDTO(x)).ToArray();
            }
        }

        [HttpGet]
        [Route("api/login/{id}")]
        public async Task<LoginDTO> Get(int id)
        {
            using (var repo = new LoginRepository())
            {
                Login existing = await repo.GetById(id);
                if (existing == null) { throw new HttpResponseException(HttpStatusCode.NotFound); }
                return new LoginDTO(existing);
            }
        }

        [HttpGet]
        [Route("api/login/{email}")]
        public async Task<LoginDTO> GetbyEmail(string email)
        {
            using (var repo = new LoginRepository())
            {
                Login existing = await repo.GetByEmail(email);
                if (existing == null) { throw new HttpResponseException(HttpStatusCode.NotFound); }
                return new LoginDTO(existing);
            }
        }

        [HttpPost]
        [Route("api/login/create")]
        public async Task<int> Post(LoginDTO item)
        {
            using (var repo = new LoginRepository())
            {
                Login login = new Login();
                item.Save(login);

                await repo.Create(login);
                await repo.Commit();
                return login.Id;
            }
        }

        [HttpPut]
        [Route("api/login")]
        public async Task Put(LoginDTO item)
        {
            using (var repo = new LoginRepository())
            {
                Login existing = await repo.GetById(item.Id);
                if (existing == null) { throw new HttpResponseException(HttpStatusCode.NotFound); }
                item.Save(existing);
                await repo.Commit();
            }
        }

        [HttpDelete]
        [Route("api/login")]
        public async Task Delete(LoginDTO item)
        {
            using (var repo = new LoginRepository())
            {
                Login existing = await repo.GetById(item.Id);
                if (existing == null) { return; }
                await repo.Delete(existing);
                await repo.Commit();
            }
        }
    }
}