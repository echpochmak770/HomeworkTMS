using System;
using System.Collections.Generic;
using System.Text;

namespace HomeworkTMS.DocumentAccounting
{
    internal class ProductSupplyAgreement : IDocument
    {
        public int DocumentId { get; init; } = DocumentIdGenerator.GetNextId();
        public DateOnly DocumentDate { get; init; } = DateOnly.FromDateTime(DateTime.Now);
        public int ProductQuantity { get; init => field = value >= 0 ? value : throw new ArgumentException("Товаров не может быть меньше 0"); }
        public ProductType ProductType { get; init; }

        public ProductSupplyAgreement(int productQuantity, ProductType productType)
        {
            ProductQuantity = productQuantity;
            ProductType = productType;
        }

        public void GetInfo()
        {
            Console.WriteLine($"Контракт на поставку товаров" +
                $"\nИдентификатор документа: {DocumentId}" +
                $"\nДата заключения контракта: {DocumentDate}" +
                $"\nКоличество товаров: {ProductQuantity}" +
                $"\nТип товара: {ProductType}\n");
        }
    }

    enum ProductType
    {
        Electronics,
        Clothing,
        Food,
        Unspecified
    }
}
