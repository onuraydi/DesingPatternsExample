using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    public class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer();
            Console.WriteLine(customer.FirstName = "Onur");
            Console.WriteLine(customer.LastName = "Aydi");
            Console.WriteLine(customer.Id = 19);
            Console.WriteLine(customer.City = "Istanbul");

            Console.WriteLine();

            var customer2 = (Customer)customer.Clone();
            Console.WriteLine(customer2.FirstName = "Yavuz");
            Console.WriteLine(customer2.LastName = "Ozkan");
            Console.WriteLine(customer2.Id = 57);
            Console.WriteLine(customer2.City = "Ankara");

            Console.ReadLine();
        }
    }
    public abstract class Person
    {
        public abstract Person Clone();
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class  Customer: Person
    {
        public string City { get; set; }

        public override Person Clone()
        {
            return (Person)MemberwiseClone();
        }
    }
}
