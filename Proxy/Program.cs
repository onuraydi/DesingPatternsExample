using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Proxy
{
    public class Program
    {
        static void Main(string[] args)
        {
            CreditManagerProxy credit = new CreditManagerProxy();
            Console.WriteLine(credit.Calculate());

            Console.WriteLine(credit.Calculate());    // Bu da aynı hesabı yapmaya kodlandı ancak proxy'nin özelliğinden dolayı
            Console.ReadLine();                       // bu hesap bize daha çabuk gelecek
        }
    }
    abstract class CreditBase
    {
        public abstract int Calculate();
    }
    class CreditManager:CreditBase
    {
        public override int Calculate() 
        {
            int result = 1;
            for(int i = 1; i < 5; i++) 
            {
                result *= i;
                Thread.Sleep(1000);
            }
            return result;
        }
    }
    class CreditManagerProxy : CreditBase
    {
        private CreditManager _creditManager;
        private int _cachedValue;
        public override int Calculate()
        {
            if(_creditManager == null)
            {
                _creditManager = new CreditManager();
                _cachedValue = _creditManager.Calculate();
            }

            return _cachedValue;
        }
    }
}
