using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Resources.DTOs
{
    public enum eHMODTO { macabi=1, clalit, meuchedet }
    public enum eGenderDTO { male=1,female}
    public enum eRoleDTO { manager=1,employee}
    public class UserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public eRoleDTO Role { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public eGenderDTO Gender { get; set; }
        public eHMODTO Hmo { get; set; }
    }
}
