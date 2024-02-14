using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    public class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.Save();

            Console.Read();
        }
    }
    class Logging:ILogging
    {
        public void Log()
        {
            Console.WriteLine("Logged!");
        }
    }

    public interface ILogging
    { 
        void Log(); 
    }
                   
    class Caching:ICaching
    {
        public void Cached()
        {
            Console.WriteLine("Cached!");
        }
    }

    public interface ICaching
    {
        void Cached();
    }
    class Authorize:IAuthorize
    {
        public void CheckUser()
        {
            Console.WriteLine("Used Checked!");
        }
    }
    public interface IAuthorize
    {
        void CheckUser();
    }
    class CustomerManager
    {
        private CrossCuttingConcernsFacade _conserns;    
        public CustomerManager()
        {
            _conserns = new CrossCuttingConcernsFacade();
        }

        public void Save()
        {
            _conserns.Logging.Log();
            _conserns.Caching.Cached();
            _conserns.Authorize.CheckUser();
            Console.WriteLine("Saved!");
        }
    }

    class CrossCuttingConcernsFacade
    {
        public ILogging Logging;
        public ICaching Caching;
        public IAuthorize Authorize;

        public CrossCuttingConcernsFacade()
        {
            Logging = new Logging();
            Caching = new Caching();
            Authorize = new Authorize();
        }
    }
}
