using Core.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace CoreMeetUp.Controllers
{
        public class CategoryController : ApiController
        {
            //private DatabaseContext _context;

            [HttpGet]
            [Route("api/category")]
            public async Task<dynamic> GetCategories()
            {
                using (var db = new DatabaseContext())
                {
                    await db.SaveChangesAsync(); // if changes were made
                    return db.Category.ToList();
                }
            }


        }
    }