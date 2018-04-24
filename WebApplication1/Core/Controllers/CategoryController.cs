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
        [HttpGet]
        [Route("api/parentguardianreport")]
        public async Task<Category[]> GetParentGuardianReports()
        {
            return (await ParentGuardianReportManager.GetParentGuardianReports())
                .Select(x => new Category(x))
                .ToArray();
        }


    }
}
