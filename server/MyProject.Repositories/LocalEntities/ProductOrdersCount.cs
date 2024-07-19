using MyProject.Repositories.Entities;

namespace MyProject.Repositories.LocalEntities
{
    public class ProductOrdersCount
    {
        public Product Product { get; set; }
        public int OrdersCount { get; set; }
    }
}
