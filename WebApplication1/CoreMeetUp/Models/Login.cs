using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Database.Models
{
    public class Login
    {
        public int Id { get; set; }
        public string Pass { get; set; }
        public string Email { get; set; }
        [Required] public virtual Person Person { get; set; }
    }
}
