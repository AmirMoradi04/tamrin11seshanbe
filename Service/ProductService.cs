using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tamrin11.Loger;
using tamrin11.Repasitory;

namespace tamrin11.Service
{
    public class ProductService
    {
        private IProductRepository _productRepository;
        private ILogger _logger;
        public ProductService(IProductRepository productRepository, ILogger logger)
        {
            _productRepository = productRepository;
            _logger = logger;
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
                Console.WriteLine("product add shod");
                return true;


            }
            catch 
            {
            throw new Exception($"Product");
            }


        }

        public bool RemoveUser(string sku)
        {
            try
            {
                bool removed = _productRepository.Delete( sku);

                if (!removed)
                {
                    throw new Exception("product peyda nashod");

                }
                _logger.Log("hazf movafagh bud");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError("khata dar hazfe product : " + ex.Message);
                return false;
            }
        }

        public ProductItem? GetProductItemName(string name)
        {
            return _productRepository.GetByName(name);
             

        }

        public List<ProductItem> GetAllProduct()
        {
            return _productRepository.GetAll();
        }









    }
}
