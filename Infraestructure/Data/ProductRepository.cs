using Domain.Entities;
using Domain.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Data
{
    public class ProductRepository : IProductRepository
    {
        static int LastIdAssigned = 0;
        static List<Product> products = [];

        public List<Product> GetProducts()
        {
            return products.ToList();
        }

        public Product GetProductById(int id)
        {
            return products.FirstOrDefault(x => x.Id == id);
        }

        public Product GetProductByName(string name)
        {
            return products.FirstOrDefault(x => x.Name == name);
        }

        public Product CreateProduct(Product product)
        {
            product.Id = ++LastIdAssigned;
            products.Add(product);
            return product;
        }

        public void UpdateProduct(Product product)
        {
            var obj = products.FirstOrDefault(x => x.Id == product.Id);
            obj.Name = product.Name;
        }

        public void DeleteProduct(Product product)
        {
            products.Remove(product);
        }
    }
}
