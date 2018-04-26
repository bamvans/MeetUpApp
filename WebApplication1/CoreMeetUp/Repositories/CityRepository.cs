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
    public class CityRepository:BaseRepository
    {
        #region Get

        public Task<City[]> GetAll()
        {
            return context.City.ToArrayAsync();
        }

        public Task<City> GetById(int id)
        {
            return context.City.FirstOrDefaultAsync(x => x.Id == id);
        }

        #endregion

        #region Create

        public Task Create(City city)
        {
            context.City.Add(city);
            return Task.FromResult(true);
        }

        #endregion

        #region Delete

        public Task Delete(City city)
        {
            context.City.Remove(city);
            return Task.FromResult(true);
        }

        #endregion
    }
}