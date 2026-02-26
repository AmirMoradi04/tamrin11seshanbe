using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tamrin11.Service
{
    public class InvalidQuantityException:Exception
    {
        public InvalidQuantityException(string massage) : base(massage)
        {
            
        }
    }
}
