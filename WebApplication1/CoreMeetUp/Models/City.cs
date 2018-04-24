using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Database.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Group> Group { get; set; }
    }
}
