using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Repositories.Entities
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Product")]///do not show all the object       
        public int? ProductId { get; set; }
        public Product? Product { get; set; }
        public int Count { get; set; }
        public DateTime Date { get; set; }
    }
}
