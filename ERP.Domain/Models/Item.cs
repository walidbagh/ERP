using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Domain.Models
{
    public class Item : DomainObject
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

    }
}
