using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain;
using Shop.Domain._Shared.Exceptions;
using Shop.Domain.ProductsAgg.ValueObjects;
using Test.Domain.Shared.Exceptions;

namespace Shop.Domain.ProductsAgg
{
    public class Product : AggregateRoot
    {
        private Product() { }
        public Product(string productName, string productCode, Price productPrice, int count, int totalRate, string title, string description,
            string color, string category, bool bestSelling, int design, int purchaseValue, int buildQuality, int featured, Discount productDiscount)
        {
            Guard(productName, productCode, count, totalRate, title, description, color, category, design, purchaseValue, buildQuality, featured);
            ProductName = productName;
            ProductCode = productCode;
            ProductPrice = productPrice;
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
            ProductDiscount = productDiscount;
            Comments = new List<Comment>();
            Faqs = new List<Faq>();
            Images = new List<ProductIImage>();
        }
        public string ProductName { get; private set; }
        public string ProductCode { get; private set; }
        public Price ProductPrice { get; private set; }
        public Discount ProductDiscount { get; private set; }
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
        public List<Comment> Comments { get; private set; }
        public List<Faq> Faqs { get; private set; }
        public List<ProductIImage> Images { get; private set; }

        public void Edit(string productName, string productCode, Price productPrice, int count, int totalRate, string title, string description,
            string color, string category, bool bestSelling, int design, int purchaseValue, int buildQuality, int featured, Discount productDiscount)
        {
            Guard(productName, productCode, count, totalRate, title, description, color, category, design, purchaseValue, buildQuality, featured);
            ProductName = productName;
            ProductCode = productCode;
            ProductPrice = productPrice;
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
            ProductDiscount = productDiscount;
        }

        public void AddComment(Comment comment)
        {
            comment.ProductId = Id;
            Comments.Add(comment);

        }

        public void EditComment(long id, Comment comment)
        {
            var oldComment = Comments.FirstOrDefault(f => f.Id == id);
            if (oldComment == null)
                throw new InvalidDomainDataExcepion("آیدی وارد شده نامعتبر یا وجود ندارد");
            Comments.Remove(oldComment);
            Comments.Add(comment);
        }

        public void RemoveComment(long id)
        {
            var oldComment = Comments.FirstOrDefault(f => f.Id == id);
            if (oldComment == null)
                throw new InvalidDomainDataExcepion("آیدی وارد شده نامعتبر یا وجود ندارد");
            Comments.Remove(oldComment);
        }

        public void AddFaq(Faq faq)
        {
            faq.ProductId = Id;
            Faqs.Add(faq);
        }

        public void EditFaq(long id, Faq faq)
        {
            var oldFaq = Faqs.FirstOrDefault(f => f.Id == id);
            if (oldFaq == null)
                throw new InvalidDomainDataExcepion("آیدی وارد شده نامعتبر یا وجود ندارد");
            Faqs.Remove(oldFaq);
            Faqs.Add(faq);
        }

        public void RemoveFaq(long id)
        {
            var oldFaq = Faqs.FirstOrDefault(f => f.Id == id);
            if (oldFaq == null)
                throw new InvalidDomainDataExcepion("آیدی وارد شده نامعتبر یا وجود ندارد");
            Faqs.Remove(oldFaq);
        }

        public void AddImage(ProductIImage image)
        {
            image.ProductId = Id;
            Images.Add(image);
        }

        private void Guard(string productName, string productCode, int count, int totalRate, string title, string description,
            string color, string category, int design, int purchaseValue, int buildQuality, int featured)
        {
            NullOrEmptyDomainDataException.CheckString(productName, nameof(productName));
            NullOrEmptyDomainDataException.CheckString(productCode, nameof(productCode));
            NullOrEmptyDomainDataException.CheckString(title, nameof(title));
            NullOrEmptyDomainDataException.CheckString(description, nameof(description));
            NullOrEmptyDomainDataException.CheckString(color, nameof(color));
            NullOrEmptyDomainDataException.CheckString(category, nameof(category));

            if (count < 1)
                throw new InvalidDomainDataExcepion("تعداد وارد شده نامعتبر است");

            if (totalRate < 1 || totalRate > 5)
                throw new InvalidDomainDataExcepion("بازه وارد شده باید بین 5 و 1 باشد");

            if (design < 0 || design > 100)
                throw new InvalidDomainDataExcepion("بازه وارد شده باید بین 100 و 0 باشد");

            if (purchaseValue < 0 || purchaseValue > 100)
                throw new InvalidDomainDataExcepion("بازه وارد شده باید بین 100 و 0 باشد");

            if (buildQuality < 0 || buildQuality > 100)
                throw new InvalidDomainDataExcepion("بازه وارد شده باید بین 100 و 0 باشد");

            if (featured < 0 || featured > 100)
                throw new InvalidDomainDataExcepion("بازه وارد شده باید بین 100 و 0 باشد");
        }
    }
}
