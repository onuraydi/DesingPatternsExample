using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    public class Program
    {
        static void Main(string[] args)
        {
            ProductDirector director = new ProductDirector();
            var builder = new NewCustomerProductBuilder();
            director.GenerateProduct(builder);

            var model = builder.GetModel();

            Console.WriteLine(model.Id);
            Console.WriteLine(model.CategoryName);
            Console.WriteLine(model.ProductName);
            Console.WriteLine(model.UnitPrice);

            Console.WriteLine(model.DiscountedPrice);
            Console.WriteLine(model.DiscountApplied);

            Console.ReadLine();
        }
    }
    class ProductWiewModel
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal DiscountedPrice { get; set; }
        public bool DiscountApplied { get; set; }
    }
    abstract class ProductBuilder
    {
        public abstract void GetProductData();
        public abstract void ApplyDiscount();
        public abstract ProductWiewModel GetModel();
    }
    
    class NewCustomerProductBuilder:ProductBuilder
    {
        ProductWiewModel model = new ProductWiewModel();
        public override void GetProductData()
        {
            model.Id = 1;                                   // Temel bilgileri buraya yazdık.
            model.CategoryName = "Technology";
            model.ProductName = "Laptop";
            model.UnitPrice = 75000;
        }

        public override void ApplyDiscount()
        {                                                  // İndirim ile ilgili bilgileri buraya yazdık.
            model.DiscountedPrice = model.UnitPrice*(decimal)0.97;
            model.DiscountApplied = true;
        }

        public override ProductWiewModel GetModel() 
        {
            return model;
        }
    }

    class OldCustomerProductBuilder:ProductBuilder
    {
        ProductWiewModel model = new ProductWiewModel();
        public override void GetProductData()
        {
            model.Id = 2;
            model.CategoryName = "Technology";
            model.ProductName = "Laptop";
            model.UnitPrice = 75000;
        }

        public override void ApplyDiscount()
        {
            model.DiscountedPrice = model.UnitPrice;
            model.DiscountApplied = false;
        }

        public override ProductWiewModel GetModel()
        {
            return model;
        }
    }
    
    class ProductDirector
    {
        public void GenerateProduct(ProductBuilder productBuilder)
        {
            productBuilder.GetProductData();
            productBuilder.ApplyDiscount();
        }
    }
}
