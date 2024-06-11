using Application.Interfaces;
using Application.Models;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public List<Product> GetProducts()
        {
            return _productRepository.GetProducts();
        }
        public Product GetProductById(int id)
        {
            return _productRepository.GetProductById(id);
        }
        public Product GetProductByName(string name)
        {
            return _productRepository.GetProductByName(name);
        }

        public Product CreateProduct(ProductDto product)
        {
            var productCreate = new Product()
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Stock = product.Stock,
                Image = product.Image,
                Category = product.Category,
                Brand = product.Brand
            };
            _productRepository.CreateProduct(productCreate);
            return _productRepository.GetProductById(productCreate.Id);
        }

        public void UpdateProduct(int id, ProductDto product)
        {
            var productUpdate = _productRepository.GetProductById(id);
            productUpdate.Name = product.Name;
            productUpdate.Description = product.Description;
            productUpdate.Stock = product.Stock;
            productUpdate.Price = product.Price;
            productUpdate.Image = product.Image;
            productUpdate.Category = product.Category;
            productUpdate.Brand = product.Brand;
            _productRepository.UpdateProduct(productUpdate);
        }

        public void DeleteProduct(int id)
        {
            var productDelete = _productRepository.GetProductById(id);
            _productRepository.DeleteProduct(productDelete);
        }
    }
}
