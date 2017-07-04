using System;
using System.Collections.Generic;
using DiscountManagement.Domain;
using DiscountManagement.Domain.DiscountEvaluator;
using DiscountManagement.Domain.DiscountRules;
using DiscountManagement.Domain.DomainObjects;
using DiscountManagement.Domain.NamedCriteria;
using DiscountManagement.Test.UnitTest;
using NUnit.Framework;

namespace DiscountManagement.Test.IntegrationTest
{
    [TestFixture]
    class BillGenerationTest
    {
        private IDiscountEvaluator _discountEvaluator;

        [SetUp]
        public void SetUp()
        {
            var excludeGroceriesCriteria = new ProductExclusionCriteria().ExcludeCategory("Groceries");
            List<IDiscountRule> discountRules = new List<IDiscountRule>
            {
                new UserTypeDiscountRule<Employee>(30, excludeGroceriesCriteria),
                new UserTypeDiscountRule<Affiliate>(10, excludeGroceriesCriteria),
                new LoyalCustomerDiscountRule(5, 2, new DateTime(2017,7,7), excludeGroceriesCriteria),
                new BillAmountDiscountRule(100, 5)
            };
            _discountEvaluator = new DiscountEvaluator(discountRules);
        }

        [Test]
        public void Return_30_Percent_Discount_For_Employee()
        {
            Order order = TestDataSource.Order;
            order.OrderedBy = new Employee {Name = "Test User"};

            Bill bill = new Bill(order,_discountEvaluator);
            bill.ApplyDiscount();

            // Eligible For 2 Discounts but 30% Discount rule is chosen
            // Total Bill : 995, Groceries : 95 , Discount : 30% of 900 => 270, so Bill : 995-270 => 725

            Assert.AreEqual(725, bill.Amount);
        }

        [Test]
        public void Return_10_Percent_Discount_For_Affiliate()
        {
            Order order = TestDataSource.Order;
            order.OrderedBy = new Affiliate { Name = "Test User" };

            Bill bill = new Bill(order, _discountEvaluator);
            bill.ApplyDiscount();

            // Total Bill : 995, Groceries : 95 , Discount : 10% of 900 => 90, so Bill : 995-90 => 905
            Assert.AreEqual(905, bill.Amount);
        }

        [Test]
        public void Return_5_Percent_Discount_For_More_Than_2Years_Old_Customer()
        {
            Order order = TestDataSource.Order;
            order.OrderedBy = new Customer() { Name = "Test User", FirstPurchaseDate = DateTime.Now.AddYears(-3)};

            Bill bill = new Bill(order, _discountEvaluator);
            bill.ApplyDiscount();

            // Total Bill : 995, Groceries : 95 , Discount : 5% of 900 => 45, so Bill : 995-45 => 950
            Assert.AreEqual(950, bill.Amount);
        }

        [Test]
        public void Return_5Rs_Discount_For_Every_100_Rs_For_Customers_Less_Than_2_Years()
        {
            Order order = TestDataSource.Order;
            order.OrderedBy = new Customer() { Name = "Test User", FirstPurchaseDate = DateTime.Now.AddYears(-1) };

            Bill bill = new Bill(order, _discountEvaluator);
            bill.ApplyDiscount();

            // Total Bill : 995, Groceries : 95 , Discount : 5 for 100 , so for 900 = 9*5 = 45 Bill : 995-45 = 950
            Assert.AreEqual(950, bill.Amount);
        }


    }
}
