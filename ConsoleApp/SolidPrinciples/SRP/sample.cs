using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples.SRP
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
    public class OrderUnit
    {
        public void Checkout(Cart cart, PaymentDetails paymentDetails, bool notifyCustomer)
        {
            if (paymentDetails.PaymentMethod == PaymentMethod.Check)
            {
                ProcessCheck(paymentDetails, cart);
            }

            ReserveUnit(cart);

            //Process Payment

            if (notifyCustomer)
            {
                NotifyCustomer(cart);
            }
        }

        public void NotifyCustomer(Cart cart)
        {
            string customerEmail = cart.CustomerEmail;
            if (!String.IsNullOrEmpty(customerEmail))
            {
                //using (var message = new MailMessage("orders@somewhere.com", customerEmail))
                //using (var client = new SmtpClient("localhost"))
                //{
                //    message.Subject = "Your order placed on " + DateTime.Now.ToString();
                //    message.Body = "Your order details: \n " + cart.ToString();

                //    try
                //    {
                //        client.Send(message);
                //    }
                //    catch (Exception ex)
                //    {
                //        Logger.Error("Problem sending notification email", ex);
                //    }
                //}
            }
        }

        public void ReserveUnit(Cart cart)
        {
            foreach (var item in cart.Units )
            {
                try
                {
                    var inventorySystem = new InventorySystem();
                    inventorySystem.Reserve(item.UnitName , item.Quantity);

                }
                catch (UnitNotAvailableException ex)
                {
                    throw new OrderUnitException(String.Format("Unit{0} is not available",item.UnitName ), ex);
                }
                catch (Exception ex)
                {
                    throw new OrderUnitException("Problem reserving the unit", ex);
                }
            }
        }

        public void ProcessCheck(PaymentDetails paymentDetails, Cart cart)
        {
           //Fillout form 
           //Get Check Detail
           //Validate Check
           //Validate check amount versus Items in Cart
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
}

