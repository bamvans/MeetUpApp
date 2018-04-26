using CoreMeetUp.Models;
using CoreMeetUp.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CoreMeetUp.Repositories
{
    public class CategoryRepository:BaseRepository
    {
        #region Get

        public Task<Category[]> GetAll()
        {
            return context.Category.ToArrayAsync();
        }

        public Task<Category> GetById(int id)
        {
            return context.Category.FirstOrDefaultAsync(x => x.Id == id);
        }

        #endregion

        #region Create

        public Task Create(Category category)
        {
            context.Category.Add(category);
            return Task.FromResult(true);
        }

        #endregion

        #region Delete

        public Task Delete(Category category)
        {
            context.Category.Remove(category);
            return Task.FromResult(true);
        }

        #endregion
    }
}