using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            //CustomerManager customerManager = new CustomerManager();//bu şekilde kullanamayız
            var customerManager = CustomerManager.CreateAsSingleton();//bu şekilde kullanmalıyız.
            customerManager.save();

            Console.Read();
        }
    }
    class CustomerManager
    {
        private static CustomerManager _customerManager;
        static object _lockObcejct = new object();

        // bu şekilde bu obje yani nesne artık sadece bir kez tanımlanabilecek.(new işlemi bir kere yapılabilecek)
        // bu kullanım birden fazla kişinin çalıştığı projelerde oldukça iş görmektedir. 
        private CustomerManager()
        {
            lock (_lockObcejct)
            {
                if(_lockObcejct == null)
                {
                    _customerManager = new CustomerManager();
                }
            }
        } 
        
        public static CustomerManager CreateAsSingleton()
        {
            // return _customerManager ?? (_customerManager = new CustomerManager());

            if (_customerManager == null) 
            {
                _customerManager = new CustomerManager();
            }

            return _customerManager;
        }

        public void save()
        {
            Console.WriteLine("Saved!!");
        }
    }
}
