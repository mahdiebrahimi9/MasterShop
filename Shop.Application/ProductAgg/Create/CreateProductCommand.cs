using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Shop.Domain.ProductsAgg.ValueObjects;

namespace Shop.Application.ProductAgg.Create
{
    public class CreateProductCommand : IRequest
    {
        public CreateProductCommand(string productName, string productCode, Price productPrice, Discount productDiscount, int count, int totalRate, string title, string description, string color, string category, bool bestSelling, int design, int purchaseValue, int buildQuality, int featured)
        {
            ProductName = productName;
            ProductCode = productCode;
            ProductPrice = productPrice;
            ProductDiscount = productDiscount;
            Count = count;
            TotalRate = totalRate;
            Title = title;
            Description = description;
            Color = color;
            Category = category;
            BestSelling = bestSelling;
            Design = design;
            PurchaseValue = purchaseValue;
            BuildQuality = buildQuality;
            Featured = featured;
        }
        public string ProductName { get;  set; }
        public string ProductCode { get;  set; }
        public Price ProductPrice { get;  set; }
        public Discount ProductDiscount { get;  set; }
        public int Count { get;  set; }
        public int TotalRate { get;  set; }
        public string Title { get;  set; }
        public string Description { get;  set; }
        public string Color { get;  set; }
        public string Category { get;  set; }
        public bool BestSelling { get;  set; }
        public int Design { get;  set; }
        public int PurchaseValue { get;  set; }
        public int BuildQuality { get;  set; }
        public int Featured { get;  set; }
    }
}
