using System.Linq;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using System.Data;
namespace SportsStore.Domain.Concrete
{
    public class EFProductRepository : IProductRepository
    {
        private EFDbContext context = new EFDbContext();

        public IQueryable<Product> Products
        {
            get { return context.Products; }
        }

        public void SaveProduct(Product product)
        {
            if (product.ProductId == 0)
            {
                context.Products.Add(product);
            }
            else
            {
                context.Products.Attach(product);
                if (product.ImageData == null)
                {
                    var entry = context.Entry(product);
                    foreach (var name in entry.CurrentValues.PropertyNames.Where(x => x != "ImageData"))
                    {
                        entry.Property(name).IsModified = true;
                    }
                }
                else 
                {
                    context.Entry(product).State = EntityState.Modified;
                }
            }
            context.SaveChanges();
        }

        public void DeleteProduct(Product product)
        {
            context.Products.Remove(product);
            context.SaveChanges();
        }
    }
}
