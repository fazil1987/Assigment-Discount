using DiscountManagement.Domain;
using DiscountManagement.Domain.DiscountRules;
using Moq;
using NUnit.Framework;

namespace DiscountManagement.Test
{
    [TestFixture]
    public class BillTest
    {
        private Bill _bill;
        private Mock<IDiscountEvaluator> _discountEvaluator;

        [SetUp]
        public void SetUp()
        {
            _discountEvaluator = new Mock<IDiscountEvaluator>();
        }

        [Test]        
        public void Bill_Amount_After_Discount()
        {
            _discountEvaluator.Setup(i => i.Evaluate(It.IsAny<Order>())).Returns(50);
            
            _bill = new Bill(TestDataSource.Order, _discountEvaluator.Object);
            _bill.ApplyDiscount();

            Assert.AreEqual(945, _bill.Amount);
        }

    }
}
