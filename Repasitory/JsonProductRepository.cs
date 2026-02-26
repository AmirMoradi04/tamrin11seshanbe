using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace tamrin11.Repasitory
{
    public class JsonProductRepository : IProductRepository
    {
        private string _filePathProduct = "Data/product.json";
        //private readonly ILogger _logger;
        private List<ProductItem> _product;
        public void FileExist()
        {
            Directory.CreateDirectory("Data");
            if (!File.Exists(_filePathProduct))
            {
                File.WriteAllText(_filePathProduct, "[]");
            }
        }
        private void SaveChanges()
        {
            string json = JsonSerializer.Serialize(_product);
            File.WriteAllText(_filePathProduct, json);
        }
        public bool Add(ProductItem product)
        {

            if (_product == null)
            {
                _product = new List<ProductItem>();
            }
            _product.Add(product);
            SaveChanges();
            return true;

        }

        public bool Delete(string sku)
        {
            ProductItem? productRemove = null;
            foreach (var product in _product)
            {
                if (product.Sku == sku)
                {
                    productRemove = product;
                    break;
                }
            }

            if (productRemove != null)
            {
                _product.Remove(productRemove);
                SaveChanges();
                return true;
            }

            return false;
        }


        public List<ProductItem> GetAll()
        {
            return _product;
        }


        public ProductItem? GetByName(string name)
        {
            foreach (var prod in _product)
            {
                if (prod.Name == name)
                    return prod;
            }

            return null;

        }
        public bool Update(string sku,ProductItem product)
        {
            foreach (var exist in _product)
            {
                if (exist.Sku == sku)
                {   
                     exist.Name= product.Name;
                    exist.Quantity= product.Quantity;
                    SaveChanges();
                    return true;
                }
            }

            return false;
        }
    }
}
