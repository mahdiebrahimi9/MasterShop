using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain;
using Shop.Domain._Shared.Exceptions;

namespace Shop.Domain.ProductsAgg.ValueObjects
{
    public class Price:ValueObject
    {
        public Price(int value)
        {
            if (value < 1)
                throw new InvalidDomainDataExcepion("مبلغ وارد شده نامعتبر است");
            Value = value;
        }

        public int Value { get; private set; }
    }
}
