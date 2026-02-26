using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tamrin11.Service
{
    public class ProductNotFoundException:Exception
    {
        public ProductNotFoundException(string massage):base(massage)
        {
            
        }

    }
}
