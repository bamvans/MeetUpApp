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
    public class LoginRepository : BaseRepository
    {
        #region Get

        public Task<Login[]> GetAll()
        {
            return context.Login.ToArrayAsync();
        }

        public Task<Login> GetById(int id)
        {
            return context.Login.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<Login> GetByEmail(string email)
        {
            return context.Login.FirstOrDefaultAsync(x => x.Email == email);
        }
        #endregion

        #region Create

        public Task Create(Login login)
        {
            context.Login.Add(login);
            return Task.FromResult(true);
        }

        #endregion

        #region Delete

        public Task Delete(Login login)
        {
            context.Login.Remove(login);
            return Task.FromResult(true);
        }

        #endregion
    }
}