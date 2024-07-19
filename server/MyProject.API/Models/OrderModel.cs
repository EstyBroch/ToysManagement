using MyProject.Repositories.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace MyProject.WebAPI.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        [ForeignKey("Product")]///do not show all the object       
        public int? ProductId { get; set; }
        public Product? Product { get; set; }
        public int Count { get; set; }
        public DateTime Date { get; set; }
    }
}
