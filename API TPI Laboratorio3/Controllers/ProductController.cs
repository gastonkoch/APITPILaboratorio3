using Application.Interfaces;
using Application.Models;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_TPI_Laboratorio3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public ActionResult<List<Product>> GetProducts() 
        {
            try
            {
                return Ok(_productService.GetProducts());
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("id/{id}")]
        public ActionResult<Product> GetProductById([FromRoute] int id)
        {
            try
            {
                return Ok(_productService.GetProductById(id));
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("name/{name}")]
        public ActionResult<Product> GetProductByName([FromRoute] string name)
        {
            try
            {
                return Ok(_productService.GetProductByName(name));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public void UpdateProduct([FromRoute] int id, [FromBody] ProductDto product)
        {
            _productService.UpdateProduct(id, product);
        }

        [HttpDelete("{id}")]
        public void DeleteProduct([FromRoute] int id)
        {
            _productService.DeleteProduct(id);
        }

        [HttpPost]
        public Product CreateProduct([FromBody] ProductDto product)
        {
            return _productService.CreateProduct(product);
        }
    }
}
