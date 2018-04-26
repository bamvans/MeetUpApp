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
    public class PersonController : ApiController
    {
        public async Task<PersonDTO[]> Get()
        {
            using (var repo = new PersonRepository())
            {
                return (await repo.GetAll()).Select(x => new PersonDTO(x)).ToArray();
            }
        }

        public async Task<PersonDTO> Get(int id)
        {
            using (var repo = new PersonRepository())
            {
                Person existing = await repo.GetById(id);
                if (existing == null) { throw new HttpResponseException(HttpStatusCode.NotFound); }
                return new PersonDTO(existing);
            }
        }

        public async Task<int> Post(PersonDTO item)
        {
            using (var repo = new PersonRepository())
            {
                Person person = new Person();
                item.Save(person);

                await repo.Create(person);
                await repo.Commit();
                return person.Id;
            }
        }

        public async Task Put(PersonDTO item)
        {
            using (var repo = new PersonRepository())
            {
                Person existing = await repo.GetById(item.Id);
                if (existing == null) { throw new HttpResponseException(HttpStatusCode.NotFound); }
                item.Save(existing);
                await repo.Commit();
            }
        }

        public async Task Delete(PersonDTO item)
        {
            using (var repo = new PersonRepository())
            {
                Person existing = await repo.GetById(item.Id);
                if (existing == null) { return; }
                await repo.Delete(existing);
                await repo.Commit();
            }
        }
    }
}