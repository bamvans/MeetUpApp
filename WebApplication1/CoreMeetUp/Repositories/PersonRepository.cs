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
    public class PersonRepository : BaseRepository
    {
        #region Get

        public Task<Person[]> GetAll()
        {
            return context.Person.ToArrayAsync();
        }

        public Task<Person> GetById(int id)
        {
            return context.Person.FirstOrDefaultAsync(x => x.Id == id);
        }

        #endregion

        #region Create

        public Task Create(Person person)
        {
            context.Person.Add(person);
            return Task.FromResult(true);
        }

        #endregion

        #region Delete

        public Task Delete(Person person)
        {
            context.Person.Remove(person);
            return Task.FromResult(true);
        }

        #endregion
    }
}