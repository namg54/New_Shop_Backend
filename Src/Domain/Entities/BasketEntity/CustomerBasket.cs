using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.BasketEntity
{
    public class CustomerBasket
    {
        public CustomerBasket(string id)
        {
            Id = id;
        }
        public string Id { get; set; }
        public List<CustomerBasketitem> Items { get; set; } = new();
    }
}
