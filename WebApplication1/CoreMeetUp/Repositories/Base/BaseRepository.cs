using CoreMeetUp.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CoreMeetUp.Repositories.Base
{
    public class BaseRepository : IDisposable
    {
        protected readonly DatabaseContext context;

        public BaseRepository(DatabaseContext context) { this.context = context; }
        public BaseRepository() : this(new DatabaseContext()) { }

        public virtual Task Commit()
        {
            return context.SaveChangesAsync();
        }

        public virtual void Dispose()
        {
            context.Dispose();
        }
    }
}