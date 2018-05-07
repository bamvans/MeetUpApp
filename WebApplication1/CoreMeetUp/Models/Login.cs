using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreMeetUp.Database
{
    public class Login
    {
        public int Id { get; set; }
        public string Pass { get; set; }
        public string Email { get; set; }
        [Required] public virtual Person Person { get; set; }
        [Column(TypeName = "binary"), MaxLength(32)] public byte[] PasswordHash { get; set; }
        [Column(TypeName = "binary"), MaxLength(64)] public byte[] PasswordSalt { get; set; }
    }
}
