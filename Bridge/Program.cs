using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Bridge
{
    public class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            CustomerManager customerManager2 = new CustomerManager();

            customerManager.messageSenderBase = new EmailSender();
            customerManager2.messageSenderBase = new SmsSender();

            customerManager.UpdateCustomer();   
            customerManager2.UpdateCustomer();

            Console.ReadLine();
        }
    }
    abstract class MessageSenderBase
    {
        public void Save()
        {
            Console.WriteLine("Message Saved!");
        }

        public abstract void Send(Body body);
    }
    class Body
    {
        public string Title { get; set; }
        public string  Text { get; set; }

    }

    class SmsSender:MessageSenderBase 
    {
        public override void Send(Body body) 
        {
            Console.WriteLine("{0} was sent via SmsSender!", body.Title);
        }
    }

    class EmailSender:MessageSenderBase
    { 
        public override void Send(Body body)
        {
            Console.WriteLine("{0} was sent via EmailSender!", body.Title);
        } 
    }

    class CustomerManager
    {
        public MessageSenderBase messageSenderBase { get; set; }
        public void UpdateCustomer()
        {
            messageSenderBase.Send(new Body { Title = "About the Course,"});
            Console.WriteLine("Customer updated!");
        }
    }
}
