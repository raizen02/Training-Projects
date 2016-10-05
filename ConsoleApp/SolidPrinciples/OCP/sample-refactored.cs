using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples.OCP.refactored
{
    public class Cart
    {
        private readonly List<Unit> _units;
        private readonly Customer  _customer;
        private readonly IPricingCalculator _pricingCalculator;
        public Cart() : this(new PricingCalculator())
        {
        }

        public Cart(IPricingCalculator pricingCalculator)
        {
            _pricingCalculator = pricingCalculator;
            _units = new List<Unit>();
        }


        public IEnumerable<Unit> Units
        {
            get { return _units; }
        }

        public string CustomerEmail { get; set; }

        public void Add(Unit unit)
        {
            _units.Add(unit);
        }

        public decimal TotalAmount()
        {
            decimal total = 0m;

            foreach (Unit unit in _units)
            {
                total += _pricingCalculator.CalculatePrice(unit);
 
            }
            return total;
  
        }


    }

    public class Unit
    {
        public string UnitName { get; set; }
        public bool isDiscounted { get; set; }
        public bool isPreSelling { get; set; }
        public decimal Amount { get; set; }
    }
    public class PaymentDetails
    {
        public PaymentMethod PaymentMethod { get; set; }

        public string Bank { get; set; }

        public string AccountNo { get; set; }

        public string AccountName { get; set; }

        public string BankBranch { get; set; }
    }
    public enum PaymentMethod
    {
        Cash,
        Check
    }

    public abstract class OrderUnit
    {
        protected readonly Cart _cart;

        protected OrderUnit(Cart cart)
        {
            _cart = cart;
        }

        public virtual void Checkout()
        {
            // log the order in the database
        }
    }

    public class CheckOrder : OrderUnit
    {
        private readonly INotificationService _notificationService;
        private readonly PaymentDetails _paymentDetails;
        private readonly IPaymentProcessor _paymentProcessor;
        private readonly IReservationService _reservationService;

        public CheckOrder(Cart cart, PaymentDetails paymentDetails, )
            : base(cart)
        {
            _paymentDetails = paymentDetails;
            _paymentProcessor = new PaymentProcessor();
            _reservationService = new ReservationService();
            _notificationService = new NotificationService();
        }

        public override void Checkout()
        {
            _paymentProcessor.ProcessCheck(_paymentDetails, _cart.TotalAmount());

            _reservationService.ReserveUnit(_cart.Units);

            _notificationService.NotifyCustomerOrderCreated(_cart);

            base.Checkout();
        }
    }

    public class CashOrder : OrderUnit
    {
        private readonly PaymentDetails _paymentDetails;
        private readonly IPaymentProcessor _paymentProcessor;
        private readonly IReservationService _reservationService;
        private readonly INotificationService _notificationService;

        public CashOrder(Cart cart, PaymentDetails paymentDetails)
                : base(cart)
        {
            _paymentDetails = paymentDetails;
            _reservationService = new ReservationService();
            _notificationService = new NotificationService();
        }

        public override void Checkout()
        {

            _reservationService.ReserveUnit(_cart.Units);
            _notificationService.NotifyCustomerOrderCreated(_cart);


            base.Checkout();
        }
    }

    public class Customer
    {
    public string Lastname { get; set; }
        public string Firstname { get; set; }
        public int Age { get; set; }


    }     
    

    //Mock Objects

    [Serializable]
    internal class OrderUnitException : Exception
    {
        public OrderUnitException()
        {
        }

        public OrderUnitException(string message) : base(message)
        {
        }

        public OrderUnitException(string message, Exception innerException) : base(message, innerException)
        {
        }


        protected OrderUnitException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }

    [Serializable]
    internal class UnitNotAvailableException : Exception
    {
        public UnitNotAvailableException()
        {
        }

        public UnitNotAvailableException(string message) : base(message)
        {
        }

        public UnitNotAvailableException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UnitNotAvailableException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }

    internal class InventorySystem
    {
        public InventorySystem()
        {
        }
        public void Reserve(string UnitName, int Quantity)
        { }
    }


    #region "Refactor Mock Objects"

    #region "SRP"

    #region PaymentProcessor

    public interface IPaymentProcessor
    {
        void ProcessCheck(PaymentDetails paymentDetails, decimal amount);
    }

    internal class PaymentProcessor : IPaymentProcessor
    {
        public void ProcessCheck(PaymentDetails paymentDetails, decimal amount)
        {
            //Fillout form 
            //Get Check Detail
            //Validate Check
            //Validate check amount versus Items in Cart
        }
    }

    #endregion

    #region ReservationService

    public interface IReservationService
    {
        void ReserveUnit(IEnumerable<Unit> units);
    }

    public class ReservationService : IReservationService
    {
        public void ReserveUnit(IEnumerable<Unit> items)
        {
            throw new NotImplementedException();
        }
    }

    #endregion

    #region NotificationService

    internal interface INotificationService
    {
        void NotifyCustomerOrderCreated(Cart cart);
    }

    internal class NotificationService : INotificationService
    {
        public void NotifyCustomerOrderCreated(Cart cart)
        {
            throw new NotImplementedException();
        }
    }

    #endregion

    public class OrderException : Exception
    {
        public OrderException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }


    #endregion


    #region "OCP"


    public interface IPricingCalculator
        {
            decimal CalculatePrice(Unit unit);
        }
    public interface IPriceRule
    {
        decimal CalculatePrice(Unit unit);
        bool IsMatch(Unit unit);
    }
    public class PricingCalculator : IPricingCalculator
    {
        private readonly List<IPriceRule> _pricingRules;

        public PricingCalculator()
        {
            _pricingRules = new List<IPriceRule>();
            _pricingRules.Add(new VatRule());
            _pricingRules.Add(new DiscountRule());

        }

        public decimal CalculatePrice(Unit unit)
        {
            return _pricingRules.First(r => r.IsMatch(unit)).CalculatePrice(unit);
        }

      
    }

    public class VatRule : IPriceRule
    {
        public bool IsMatch(Unit unit)
        {
            return unit.Amount > 3199000;
        }

        public decimal CalculatePrice(Unit unit)
        {
            return unit.Amount * 1.12M;
        }
    }
    public class DiscountRule : IPriceRule
    {
        public bool IsMatch(Unit unit)
        {
            return unit.isDiscounted;
        }

        public decimal CalculatePrice(Unit unit)
        {
            return unit.Amount * .8M;
        }
    }

    #endregion


    #endregion

}