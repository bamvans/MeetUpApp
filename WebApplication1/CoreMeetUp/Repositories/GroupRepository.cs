using CoreMeetUp.Database;
using CoreMeetUp.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CoreMeetUp.Repositories
{
    public class GroupRepository:BaseRepository
    {
        #region Get

        public Task<Group[]> GetAll()
        {
            return context.Group.ToArrayAsync();
        }

        public Task<Group> GetById(int id)
        {
            return context.Group.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<Group> GetByCity(string city)
        {
            return context.Group.FirstOrDefaultAsync(x => x.City.Name == city);
        }
        #endregion

        #region Create

        public async Task Create(Group group)
        {
            group.Category = await context.Category.SingleAsync(x => x.Id == group.Category.Id);
            group.City = await context.City.SingleAsync(x => x.Id == group.City.Id);
            context.Group.Add(group);
        }

        #endregion

        #region Delete

        public Task Delete(Group group)
        {
            context.Group.Remove(group);
            return Task.FromResult(true);
        }

        #endregion
    }
}