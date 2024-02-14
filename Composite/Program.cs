using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Composite
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Veri yapılarndaki Ağaç(tree) yapısına benzediği açıkça görülebilir.
            
            Employee employee1 = new Employee { Name = "Onur"};

            Employee employee2 = new Employee { Name = "Ali" };

            employee1.AddSubordinates(employee2);

            Employee employee3 = new Employee { Name = "Yavuz" };

            employee2.AddSubordinates(employee3);

            Employee employee4 = new Employee { Name = "Berat" };

            employee1.AddSubordinates((Employee)employee4);

            Console.WriteLine("{0}", employee1.Name);
            foreach (Employee manager in employee1)
            {
                Console.WriteLine("  {0}",manager.Name);
                foreach (Employee employee in manager)
                {
                    Console.WriteLine("    {0}", employee.Name);
                }
            }

            Console.Read();
        }
    }
    public interface IPerson
    {
        string Name { get; set; }
    }

    class Employee:IPerson,IEnumerable<IPerson>
    {
        List<IPerson> _subordinates = new List<IPerson>();
        
        public void AddSubordinates(IPerson person)
        {
            _subordinates.Add(person);
        }

        public void RemoveSubordinates(IPerson person)
        {
            _subordinates.Remove(person);
        }

        public IPerson GetSubordinate(int index)
        {
            return _subordinates[index];
        }
        public string Name { get; set; }
        public IEnumerator<IPerson> GetEnumerator()
        {
            foreach(var subordinate in _subordinates)
            {
                yield return subordinate;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
