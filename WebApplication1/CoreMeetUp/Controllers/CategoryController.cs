using Core.Database.Models;
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
        #region Get
        public static async Task<Category[]> GetAllAsync()
        {
            using (var db = new DatabaseContext())
            {
                return await db.Category.ToArrayAsync();
            }
        }


        public Task<Category> GetById(int id)
        {
            using (var db = new DatabaseContext())
            {
                return db.Category.FirstOrDefaultAsync(x => x.Id == id);
            }
        }

        #endregion

        #region Create
        public static async Task<int> Create(Category category)
        {
            using (var db = new DatabaseContext())
            {
                db.Category.Add(category);
                await db.SaveChangesAsync();
                return category.Id;
            }
        }

        #endregion


        #region Update

        public static async Task Update(Category category)
        {
            using (var db = new DatabaseContext())
            {
                Category existing = await db.Category.FirstOrDefaultAsync(x => x.Id == category.Id);
                if (existing == null) { throw new KeyNotFoundException(); }
                existing.Name = category.Name;
                await db.SaveChangesAsync();
            }
        }

        #endregion

        #region Delete

        public static async Task Delete(Category category)
        {
            using (var db = new DatabaseContext())
            {
                Category existing = await db.Category.FirstOrDefaultAsync(x => x.Id == category.Id);
                if (existing == null) { throw new KeyNotFoundException(); }
                db.Category.Remove(existing);
                await db.SaveChangesAsync();
            }
        }

        #endregion
    }
}