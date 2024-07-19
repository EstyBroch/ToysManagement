using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Resources.DTOs
{
    public class OrderDTO
    {
        public int Id { get; set; }
        [ForeignKey("Product")]///do not show all the object       
        public int? ProductId { get; set; }
        public ProductDTO? Product { get; set; }
        public int Count { get; set; }
        public DateTime Date { get; set; }
    }
}
