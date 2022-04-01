using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Domain.Models
{
    public class Invoice : DomainObject
    {
        public Client Client { get; set; }
        public IEnumerable<Item> Items { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime PayedAt { get; set; }

    }
}
