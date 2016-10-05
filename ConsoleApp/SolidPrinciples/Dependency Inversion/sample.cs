using Microsoft.VisualStudio.TestTools.UnitTesting;
using SolidPrinciples.OCP.refactored;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples.Dependency_Inversion
{

    class sample
    {
        public class HelloWorldHidden {
            public string Hello(string name) {
                if (DateTime.Now.Hour < 12) return "Good morning, " + name;
                if (DateTime.Now.Hour < 18) return "Good afternoon, " + name;
                return "Good evening, " + name;
            }
        }


    }
    [TestClass]
    class TestSample
    {
        //[TestMethod]
        //public void DIPpracticalExample()
        //{
        //    var paymentProcessor = new FakePaymentProcessor();
        //    var reservationService = new FakeReservationService();
        //    var notificationService = new FakeNotificationService();
        //    var cart = new Cart();
        //    var paymentDetails = new PaymentDetails()
        //    { PaymentMethod = PaymentMethod.Check  };
        //    var order = new CheckOrder(cart,
        //                                paymentDetails,
        //                                paymentProcessor,
        //                                reservationService,
        //                                notificationService);

        //    order.Checkout();

 
        //    Assert.AreEqual(cart.TotalAmount(), 10000);

        //}

        //private class FakePaymentProcessor
        //{
        //    public FakePaymentProcessor()
        //    {
        //    }
        //}

        //private class FakeReservationService
        //{
        //    public FakeReservationService()
        //    {
        //    }
        //}
    }

    internal class FakeNotificationService
    {
        public FakeNotificationService()
        {
        }
    }
}
