using CoreMeetUp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreMeetUp.Database
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Required] public virtual Category Category { get; set; }
        [Required] public virtual City City { get; set; }
    }
}
