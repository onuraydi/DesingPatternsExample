using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    public class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager(new LoggerFactory2());
            CustomerManager customerManager2 = new CustomerManager(new LoggerFactory());
            customerManager.save();
            customerManager2.save();

            Console.ReadLine();
        }
    }

    public class LoggerFactory:ILoggerFactory
    {
        public ILogger CreateLogger()
        {
            return new xLogger();
        }
    }

    public class LoggerFactory2 : ILoggerFactory
    {
        public ILogger CreateLogger()
        {
            return new yLogger();
        }
    }

    public interface ILoggerFactory
    {
        ILogger CreateLogger();
    }

    public interface ILogger
    {
        void Log();
    }
    
    public class xLogger:ILogger
        {
        public void Log()
        {
            Console.WriteLine("X logger Logged!");
        }
    }

    public class yLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Y logger Logged!");
        }
    }

    public class CustomerManager
    {
        private ILoggerFactory _loggerFactory;

        public CustomerManager(ILoggerFactory loggerFactory) 
        {
            _loggerFactory = loggerFactory;
        }
        public void save()
        {
            Console.WriteLine("Saved!");    
            ILogger logger = _loggerFactory.CreateLogger();
            logger.Log();
        }
    }

}
