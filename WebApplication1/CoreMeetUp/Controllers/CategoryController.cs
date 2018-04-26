using CoreMeetUp.Database;
using CoreMeetUp.DTO;
using CoreMeetUp.Models;
using CoreMeetUp.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace CoreMeetUp.Controllers
{
    public class CategoryController : ApiController
    {
        public async Task<CategoryDTO[]> Get()
        {
            using (var repo = new CategoryRepository())
            {
                return (await repo.GetAll()).Select(x => new CategoryDTO(x)).ToArray();
            }
        }

        public async Task<CategoryDTO> Get(int id)
        {
            using (var repo = new CategoryRepository())
            {
                Category existing = await repo.GetById(id);
                if (existing == null) { throw new HttpResponseException(HttpStatusCode.NotFound); }
                return new CategoryDTO(existing);
            }
        }

        public async Task<int> Post(CategoryDTO item)
        {
            using (var repo = new CategoryRepository())
            {
                Category category = new Category();
                item.Save(category);

                await repo.Create(category);
                await repo.Commit();
                return category.Id;
            }
        }

        public async Task Put(CategoryDTO item)
        {
            using (var repo = new CategoryRepository())
            {
                Category existing = await repo.GetById(item.Id);
                if (existing == null) { throw new HttpResponseException(HttpStatusCode.NotFound); }
                item.Save(existing);
                await repo.Commit();
            }
        }

        public async Task Delete(CategoryDTO item)
        {
            using (var repo = new CategoryRepository())
            {
                Category existing = await repo.GetById(item.Id);
                if (existing == null) { return; }
                await repo.Delete(existing);
                await repo.Commit();
            }
        }
    }
}