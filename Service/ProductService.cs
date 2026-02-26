using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tamrin11.Repasitory;

namespace tamrin11.Service
{
    public class ProductService
    {
        private IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public bool Add(string sku,int quantity,string name)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(sku))
                    throw new ProductNotFoundException("peyda nashod");
                if (quantity <= 0)
                    throw new InvalidQuantityException("mojodi zire 1 mnista");
                if (string.IsNullOrWhiteSpace(name))
                    throw new Exception("jfhgg");
                ProductItem productItem = new ProductItem()
                {
                    Sku = sku,
                    Quantity = quantity,
                    Name = name
                };
               
              
                if (!_productRepository.Add(productItem))
                {
                    throw new Exception("tekrary");
                }
                Console.WriteLine("karbar add shod");
                return true;


            }
            catch 
            {
            throw new Exception($"Product");
            }
        }

    }
}
