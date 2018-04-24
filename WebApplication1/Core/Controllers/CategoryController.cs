using Core.Database;
using Core.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Core.Controllers
{
    public class CategoryController
    {
        private MeetUpContext _context;

        [HttpGet]
        [Route("api/category")]
        public async Task<dynamic> GetCategories()
        {
            return _context.Category.ToList();
        }


    }
}
