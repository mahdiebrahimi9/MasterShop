using Shop.Domain.ProductsAgg.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.Products.DTOs
{
    public class GetProductListDto
    {
        public string ProductName { get; private set; }
        public string ProductCode { get; private set; }
        public int ProductPrice_Value { get; private set; }
        public int ProductDiscount_Amount { get; private set; }
        public int Count { get; private set; }
        public int TotalRate { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string Color { get; private set; }
        public string Category { get; private set; }
        public bool BestSelling { get; private set; }
        public int Design { get; private set; }
        public int PurchaseValue { get; private set; }
        public int BuildQuality { get; private set; }
        public int Featured { get; private set; }
    }
}
