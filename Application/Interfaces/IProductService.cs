using Application.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IProductService
    {
        public List<Product> GetProducts();
        public Product GetProductById(int id);
        public Product GetProductByName(string name);
        public Product CreateProduct(ProductDto product);
        public void UpdateProduct(int id,ProductDto product);
        public void DeleteProduct(int id);
    }
}
