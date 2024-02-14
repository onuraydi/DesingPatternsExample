using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public class Program
    {
        static void Main(string[] args)
        {
            var personalCar = new PersonalCar 
            {
                Make = "Audi", Model = "A6", HirePrice = 12500
            };
            
            SpecialOffer specialOffer = new SpecialOffer(personalCar);
            
            specialOffer.DiscountPercentage = (decimal)7.5;
            
            Console.WriteLine("Concrete: {0}",personalCar.HirePrice);
            Console.WriteLine("Special Offers: {0}", specialOffer.HirePrice);

            Console.ReadLine();
        }
    }
    abstract class CarBase
    {
        public abstract string Make { get; set; }
        public abstract string Model { get; set; }
        public abstract decimal HirePrice { get; set; }
    }

    class PersonalCar : CarBase
    {
        public override string Make { get; set; }
        public override string Model { get; set; }
        public override decimal HirePrice { get; set; }
    }

    class CommercialCar:CarBase
    {
        public override string Make { get; set; }
        public override string Model { get; set; }
        public override decimal HirePrice { get; set; }
    }

    abstract class CarDecoratorBase:CarBase
    {
        CarBase _carBase;
        protected CarDecoratorBase(CarBase carBase)
        {
            carBase = _carBase;
        }
    }

    class SpecialOffer:CarDecoratorBase
    {
        private readonly CarBase _carBase;
        public SpecialOffer(CarBase carBase):base(carBase) 
        {
            _carBase = carBase;
        }
        public decimal DiscountPercentage {  get; set; }
        public override string  Make{ get; set; }
        public override string  Model{ get; set; }
        public override decimal  HirePrice{ get { return _carBase.HirePrice - _carBase.HirePrice*DiscountPercentage/100; } set { }}
    }
}
