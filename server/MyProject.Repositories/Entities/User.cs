using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyProject.Repositories.Entities
{
    public enum eRole { manager=1,employee}
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public eRole Role { get; set; }
        public string Password { get; set; }
             
    }
}
