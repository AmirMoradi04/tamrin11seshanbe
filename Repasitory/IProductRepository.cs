using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tamrin11.Repasitory
{
    public interface  IProductRepository
    {
        bool Add(ProductItem product);

        ProductItem? GetByName(string name);

        List<ProductItem> GetAll();

        bool Update(string sku,ProductItem product);

        bool Delete(string sku);
       
       

    }
}
