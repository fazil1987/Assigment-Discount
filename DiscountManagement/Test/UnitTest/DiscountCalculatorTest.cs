using System;
using DiscountManagement.Domain.DiscountRules;
using DiscountManagement.Domain.DomainObjects;
using NUnit.Framework;
using DiscountManagement.Domain;
using DiscountManagement.Domain.NamedCriteria;

namespace DiscountManagement.Test.UnitTest
{
    [TestFixture]
    class DiscountCalculatorTest
    {
        private IDiscountRule _rule;
        private Order _testOrder;
            
        [SetUp]
        public void SetUp()
        {
            _testOrder = TestDataSource.Order;
        }

        [Test]
        public void Return_5Rs_For_Every_100Rs_On_The_Bill()
        {
            _rule = new BillAmountDiscountRule(100,5);
            var discount = _rule.CalculateDiscount(_testOrder);

            // 45 should be the discount as order total is 995
            Assert.AreEqual(45, discount);
        }

        [Test]
        public void Return_30Percent_For_Employees()
        {
            _testOrder.OrderedBy = new Employee
            {
                Name = "Test Employee"
            };

            _rule = new UserTypeDiscountRule<Employee>(30,new ProductExclusionCriteria());
            var discount = _rule.CalculateDiscount(_testOrder);
            
            Assert.AreEqual(298.5, discount);
        }

        [Test]
        public void Return_10Percent_For_Affiliates()
        {
            _testOrder.OrderedBy = new Affiliate
            {
                Name = "Test Affiliate"
            };

            _rule = new UserTypeDiscountRule<Affiliate>(10, new ProductExclusionCriteria());
            var discount = _rule.CalculateDiscount(_testOrder);
            
            Assert.AreEqual(99.5, discount);
        }
        

        [Test]
        public void Return_5Percent_For_Customer_with_2years()
        {
            _testOrder.OrderedBy = new Customer
            {
                Name = "Test Customer",
                FirstPurchaseDate = DateTime.Now.AddYears(-3)
            };
            
            _rule = new LoyalCustomerDiscountRule(5, 2, new DateTime(2017, 7, 4), null);

            var discount = _rule.CalculateDiscount(_testOrder);

            Assert.AreEqual(49.75, discount);
        }

        [Test]
        public void Return_5Percent_For_Customer_with_2years_Excluding_The_Groceries()
        {
            _testOrder.OrderedBy = new Customer
            {
                Name = "Test Customer",
                FirstPurchaseDate = DateTime.Now.AddYears(-3)
            };

            var filterGroceries = new ProductExclusionCriteria().ExcludeCategory("Groceries");

            _rule = new LoyalCustomerDiscountRule(5, 2, new DateTime(2017, 7, 4), filterGroceries);

            var discount = _rule.CalculateDiscount(_testOrder);

            Assert.AreEqual(45, discount);
        }

        [Test]
        public void Return_0Percent_For_Customer_Less_Than_2_years()
        {
            _testOrder.OrderedBy = new Customer
            {
                Name = "Test Customer",
                FirstPurchaseDate = DateTime.Now.AddYears(-1)
            };

            _rule = new LoyalCustomerDiscountRule(5, 2, new DateTime(2017, 7, 4), new ProductExclusionCriteria());

            var discount = _rule.CalculateDiscount(_testOrder);

            Assert.AreEqual(0, discount);
        }

    }
}
