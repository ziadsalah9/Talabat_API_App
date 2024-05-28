using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.Core.Models
{
    public class CustomerBasket
    {
      
        public string Id { get; set; }
        public List<Basketitem> Items { get; set; }
        public CustomerBasket(string id)
        {
            Id = id;
            Items = new List<Basketitem>();
        }

    }
}
