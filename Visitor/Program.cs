using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{
    public class Program
    {
        static void Main(string[] args)
        {
            Manager manager = new Manager { Name = "Onur", Salary = 125000};
            Manager manager2 = new Manager { Name = "Yavuz", Salary = 125000 };

            Worker worker = new Worker { Name = "Ali", Salary = 45000};
            Worker worker2 = new Worker { Name = "Ayse", Salary = 45000 };

            manager.Subordinates.Add(manager2);
            manager2.Subordinates.Add(worker);
            manager2.Subordinates.Add(worker2);

            OrganisationalSturcture organisationalSturcture = new OrganisationalSturcture(manager);

            PayrollVisitor payrollVisitor = new PayrollVisitor();
            Payrise payrise = new Payrise();

            organisationalSturcture.Accept(payrollVisitor);
            organisationalSturcture.Accept(payrise);

            Console.Read();
        }
    }
    class OrganisationalSturcture
    {
        public EmployeeBase Employee;

        public OrganisationalSturcture(EmployeeBase firstEmployeeBase)
        {
            Employee = firstEmployeeBase;
        }

        public void Accept(VisitorBase visitor)
        {
            Employee.Accept(visitor);
        }
    }

    abstract class EmployeeBase
    {
        public abstract void Accept(VisitorBase visitor);
        public string Name { get; set; }
        public decimal Salary { get; set; }
    }

    class Manager:EmployeeBase
    {
        public Manager()
        {
            Subordinates = new List<EmployeeBase>();
        }

        public List<EmployeeBase> Subordinates {  get; set; }
        public override void Accept(VisitorBase visitor)
        {
            visitor.Visit(this);

            foreach(var employee in Subordinates)
            {
                employee.Accept(visitor);
            }
        }
    }

    class Worker:EmployeeBase
    {
        public override void Accept(VisitorBase visitor)
        {
            visitor.Visit(this);
        }
    }   

    abstract class VisitorBase
    {
        public abstract void Visit(Worker worker);
        public abstract void Visit(Manager manager);

    }

    class PayrollVisitor : VisitorBase
    {
        public override void Visit(Worker worker)
        {
            Console.WriteLine("{0} paid {1}",worker.Name, worker.Salary);
        }

        public override void Visit(Manager manager)
        {
            Console.WriteLine("{0} paid {1}",manager.Name, manager.Salary);
        }
    }

    class Payrise : VisitorBase
    {
        public override void Visit(Worker worker)
        {
            Console.WriteLine("{0} salary increased to {1}", worker.Name, worker.Salary*(decimal)1.2);
        }

        public override void Visit(Manager manager)
        {
            Console.WriteLine("{0} salary increased to {1}", manager.Name, manager.Salary*(decimal)1.3);
        }
    }
}
