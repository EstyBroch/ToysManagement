using MyProject.Repositories.Entities;
using System;

namespace MyProject.WebAPI.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public eRole Role { get; set; }
        public string Password { get; set; }
       
    }
}
