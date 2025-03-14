using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain;

namespace Shop.Domain.ProductsAgg.ValueObjects
{
    public class Discount : ValueObject
    {
        public Discount(int amount)
        {
            Amount = amount;
        }

        public int Amount { get; private set; }
    }
}
