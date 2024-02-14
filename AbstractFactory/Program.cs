using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    public class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new Factory());
            ProductManager productManager2 = new ProductManager(new Factory2());
            
            productManager.GetAll();
            productManager2.GetAll();

            Console.Read();
        }
    }
    public abstract class Logging
    {
        public abstract void Log(string message);
    }

    public class Log4NetLogger:Logging
    {
        public override void Log(string message)
        {
            Console.WriteLine("Logged with Log4Net!");
        }
    }

    public class NLogger:Logging
    {
        public override void Log(string message)
        {
            Console.WriteLine("Logged with NLogger!");
        }
    }

    public abstract class Caching
    {
        public abstract void Cache(string data);
    }

    public class MemCache:Caching
    {
        public override void Cache(string data) 
        {
            Console.WriteLine("Cached with MemCache!");
        }
    }

    public class RadisCache:Caching
    {
        public override void Cache(string data)
        {
            Console.WriteLine("Cached with RadisCache!");
        }
    }

    public abstract class CrossCuttingConcernsFactory
    {
        public abstract Logging CreateLogger();
        public abstract Caching CreateCaching();
    }

    public class Factory:CrossCuttingConcernsFactory
    {
        public override Logging CreateLogger()
        {
            return new Log4NetLogger();
        }

        public override Caching CreateCaching()
        {
            return new RadisCache();
        }
    }

    public class Factory2: CrossCuttingConcernsFactory
    {
        public override Logging CreateLogger()
        {
            return new NLogger();
        }
        public override Caching CreateCaching()
        {
            return new MemCache();
        }
    }

    public class ProductManager
    {
        private CrossCuttingConcernsFactory _crossCuttingConcernsFactory;
        private Logging _logging;
        private Caching _caching;
        public ProductManager(CrossCuttingConcernsFactory crossCuttingConcernsFactory)
        {
            _crossCuttingConcernsFactory = crossCuttingConcernsFactory;
            _logging = _crossCuttingConcernsFactory.CreateLogger();
            _caching = _crossCuttingConcernsFactory.CreateCaching();
        }
        public void GetAll()
        {
            _logging.Log("Logged!");
            _caching.Cache("Cached!");
            Console.WriteLine("Products Listed!\n");
        }
    }
}
