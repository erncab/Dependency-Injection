using DI.PoorMansContainer;
using DI.PoorMansContainer.Services_Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DI.UnitTests
{
    [TestClass]
    public class CommerceTest
    {
        [TestMethod]
        public void ProcessOrderTest()
        {
            var mockBilling = new Mock<IBillingProcessorService>();

            var mockCustomer = new Mock<IInventoryService>();

            var mockNotifier = new Mock<INotifierService>();

            var mockLogger = new Mock<ILoggerService>();

            mockBilling.Setup(obj => obj.ProcessPayment(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<double>()));

            mockCustomer.Setup(obj => obj.UpdateCustomerOrder(It.IsAny<string>(), It.IsAny<string>()));

            mockNotifier.Setup(obj => obj.SendReceipt(It.IsAny<OrderInfo>()));

            mockLogger.Setup(obj => obj.Log(It.IsAny<string>()));

            var commerce = new CommerceService( mockBilling.Object,
                                                mockCustomer.Object,
                                                mockNotifier.Object,
                                                mockLogger.Object);

            commerce.ProcessOrder(new OrderInfo());

            Assert.IsTrue(true); // this test just asserts that ProcessOrder can be called without error
        }
    }
}
