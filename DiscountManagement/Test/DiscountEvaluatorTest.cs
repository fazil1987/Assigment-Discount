using System.Collections.Generic;
using DiscountManagement.Domain;
using DiscountManagement.Domain.DiscountRules;
using Moq;
using NUnit.Framework;

namespace DiscountManagement.Test
{
    [TestFixture]
    class DiscountEvaluatorTest
    {
        private DiscountEvaluator _discountEvaluator;
        private Order _testOrder;

        private Mock<IDiscountRule> _discountRule1;
        private Mock<IDiscountRule> _discountRule2;

        [SetUp]
        public void SetUp()
        {
            _testOrder = TestDataSource.Order;
            _discountRule1 = new Mock<IDiscountRule>();
            _discountRule2 = new Mock<IDiscountRule>();
        }

        [Test]
        public void Get_The_Max_Discount()
        {
            _discountRule1.Setup(i => i.CalculateDiscount(It.IsAny<Order>())).Returns(50);
            _discountRule2.Setup(i => i.CalculateDiscount(It.IsAny<Order>())).Returns(25);

            var discountRules = new List<IDiscountRule>
            {
                _discountRule1.Object,
                _discountRule2.Object
            };

            _discountEvaluator = new DiscountEvaluator(discountRules);
            var maxDiscount = _discountEvaluator.Evaluate(_testOrder);

            Assert.AreEqual(50, maxDiscount);
        }

    }
}
