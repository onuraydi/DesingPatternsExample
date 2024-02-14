using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    public class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new XLogger());
            productManager.Save();
            ProductManager productManager2 = new ProductManager(new Log4netAdapter());

            Console.WriteLine();

            productManager2.Save();
            Console.ReadLine();
        }
    }
    class ProductManager
    {
        private ILogger _logger;
        public ProductManager(ILogger logger)
        {
            _logger = logger;
        }

        public void Save()
        {
            _logger.Log("User Data!");
            Console.WriteLine("Saved!");
        }
    }
    interface ILogger
    {
        void Log(string message);
    }
    class XLogger:ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine("Logger, {0}",message);
        }
    }


    // bu kısmın nuget'tan indirdiğimiz bir dll olduğunu varsaydık. Zaten Adatper Desing Pattern'i bu yüzden kullanılır.
    class Log4Net
    {
        public void LogMessage(string message)
        {
            Console.WriteLine("Logged wiht Log4Net, {0}", message);
        }
    }

    class Log4netAdapter:ILogger
    {
        public void Log(string message)
        {
            Log4Net log4Net = new Log4Net();
            log4Net.LogMessage(message);
        }
    }
}
