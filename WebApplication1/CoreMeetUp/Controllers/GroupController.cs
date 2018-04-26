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
    public class GroupController : ApiController
    {
        [HttpGet]
        [Route("api/group")]
        public async Task<GroupDTO[]> Get()
        {
            using (var repo = new GroupRepository())
            {
                return (await repo.GetAll()).Select(x => new GroupDTO(x)).ToArray();
            }
        }

        [HttpGet]
        [Route("api/group/{id}")]
        public async Task<GroupDTO> Get(int id)
        {
            using (var repo = new GroupRepository())
            {
                Group existing = await repo.GetById(id);
                if (existing == null) { throw new HttpResponseException(HttpStatusCode.NotFound); }
                return new GroupDTO(existing);
            }
        }

        [HttpPost]
        [Route("api/group/create")]
        public async Task<int> Post(GroupDTO item)
        {
            using (var repo = new GroupRepository())
            {
                Group group = new Group();
                item.Save(group);

                await repo.Create(group);
                await repo.Commit();
                return group.Id;
            }
        }

        [HttpPut]
        [Route("api/group")]
        public async Task Put(GroupDTO item)
        {
            using (var repo = new GroupRepository())
            {
                Group existing = await repo.GetById(item.Id);
                if (existing == null) { throw new HttpResponseException(HttpStatusCode.NotFound); }
                item.Save(existing);
                await repo.Commit();
            }
        }

        [HttpDelete]
        [Route("api/group")]
        public async Task Delete(GroupDTO item)
        {
            using (var repo = new GroupRepository())
            {
                Group existing = await repo.GetById(item.Id);
                if (existing == null) { return; }
                await repo.Delete(existing);
                await repo.Commit();
            }
        }
    }
}