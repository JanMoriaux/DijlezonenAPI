using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DijleZonenApi.dijlezonen;

namespace DijleZonenApi.DAL
{
    public class ProductDAOEfImpl : ProductDAO
    {
        private readonly _1718_SPRINGDBContext dbContext;

        public ProductDAOEfImpl(_1718_SPRINGDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Product Create(string name, float price, string imageUrl, int inStock, int criticalStock)
        {
            Product newProduct = new Product(name, price, imageUrl, inStock, criticalStock);
            this.dbContext.Add(newProduct);
            this.dbContext.SaveChanges();
            return newProduct;
        }

        public void Delete(int id)
        {
            Product product = this.Get(id);
            this.dbContext.Remove(product);
            this.dbContext.SaveChanges();
        }

        public Product Get(int id)
        {
            var product = dbContext.Product.FirstOrDefault(t => t.Id == id);
            return product;
        }

        public Product[] GetAll()
        {
            return dbContext.Product.ToArray();
        }

        public Product Update(Product product)
        {
            this.dbContext.Product.Update(product);
            this.dbContext.SaveChanges();
            return product;
        }
    }
}
