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
    public class CityController : ApiController
    {
        [HttpGet]
        [Route("api/city")]
        public async Task<CityDTO[]> Get()
        {
            using (var repo = new CityRepository())
            {
                return (await repo.GetAll()).Select(x => new CityDTO(x)).ToArray();
            }
        }

        [HttpGet]
        [Route("api/city/{id}")]
        public async Task<CityDTO> Get(int id)
        {
            using (var repo = new CityRepository())
            {
                City existing = await repo.GetById(id);
                if (existing == null) { throw new HttpResponseException(HttpStatusCode.NotFound); }
                return new CityDTO(existing);
            }
        }

        [HttpPost]
        [Route("api/city/create")]
        public async Task<int> Post(CityDTO item)
        {
            using (var repo = new CityRepository())
            {
                City city = new City();
                item.Save(city);

                await repo.Create(city);
                await repo.Commit();
                return city.Id;
            }
        }

        [HttpPut]
        [Route("api/city")]
        public async Task Put(CityDTO item)
        {
            using (var repo = new CityRepository())
            {
                City existing = await repo.GetById(item.Id);
                if (existing == null) { throw new HttpResponseException(HttpStatusCode.NotFound); }
                item.Save(existing);
                await repo.Commit();
            }
        }

        [HttpDelete]
        [Route("api/city")]
        public async Task Delete(CityDTO item)
        {
            using (var repo = new CityRepository())
            {
                City existing = await repo.GetById(item.Id);
                if (existing == null) { return; }
                await repo.Delete(existing);
                await repo.Commit();
            }
        }
    }
}