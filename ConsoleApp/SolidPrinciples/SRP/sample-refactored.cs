using SolidPrinciples.SRP.Refactored;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples.SRP.Refactored
{
    public class Cart
    {
        public decimal TotalAmount { get; set; }
        public IEnumerable<Units> Units { get; set; }

        public string CustomerEmail { get; set; }
    }

    public class Units
    {
        public string UnitName { get; set; }
        public int Quantity { get; set; }
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

            public CheckOrder(Cart cart, PaymentDetails paymentDetails)
                : base(cart)
            {
                _paymentDetails = paymentDetails;
                _paymentProcessor = new PaymentProcessor();
                _reservationService = new ReservationService();
                _notificationService = new NotificationService();
            }

            public override void Checkout()
            {
                _paymentProcessor.ProcessCheck(_paymentDetails, _cart.TotalAmount);

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
    void ReserveUnit(IEnumerable<Units> units);
}

public class ReservationService : IReservationService
{
    public void ReserveUnit(IEnumerable<Units> items)
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

}