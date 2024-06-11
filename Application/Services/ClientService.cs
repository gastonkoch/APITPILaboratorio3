using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ClientService
    {
        private readonly IProductRepository _productRepository;
        public ClientService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

    }
}
