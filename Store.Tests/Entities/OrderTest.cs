using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store.Domain.Entities;
using Store.Domain.Enums;

namespace Store.Tests.Domain
{
  [TestClass]
  public class OrderTests
  {
    private readonly Customer _customer = new Customer("Kauan Hindlmayer", "kauanhindlmayer@gmail.com");
    private readonly Product _product = new Product("Produto 1", 10, true);
    private readonly Discount _discount = new Discount(10, DateTime.Now.AddDays(5));

    [TestMethod]
    [TestCategory("Domain")]
    public void ShouldReturnANumberWithEightCharactersWhenNewOrderIsValid()
    {
      var order = new Order(_customer, 0, null);
      Assert.AreEqual(8, order.Number.Length);
    }

    [TestMethod]
    [TestCategory("Domain")]
    public void ShouldReturnWaitingPaymentWhenNewOrderIsCreated()
    {
      var order = new Order(_customer, 0, null);
      Assert.AreEqual(EOrderStatus.WaitingPayment, order.Status);
    }

    [TestMethod]
    [TestCategory("Domain")]
    public void ShouldReturnWaitingDeliveryWhenOrderIsPaid()
    {
      var order = new Order(_customer, 0, null);
      order.AddItem(_product, 10);
      order.Pay(100);
      Assert.AreEqual(EOrderStatus.WaitingDelivery, order.Status);
    }

    [TestMethod]
    [TestCategory("Domain")]
    public void ShouldReturnCanceledStatusWhenOrderIsCanceled()
    {
      var order = new Order(_customer, 0, null);
      order.Cancel();
      Assert.AreEqual(EOrderStatus.Canceled, order.Status);
    }

    [TestMethod]
    [TestCategory("Domain")]
    public void OrderItemWithoutProductShouldNotBeAdded()
    {
      var order = new Order(_customer, 0, null);
      order.AddItem(null, 10);
      Assert.AreEqual(order.Items.Count, 0);
    }

    [TestMethod]
    [TestCategory("Domain")]
    public void ItemWithQuantityEqualsOrLowerThanZeroShouldNotBeAdded()
    {
      var order = new Order(_customer, 0, null);
      order.AddItem(_product, 0);
      Assert.AreEqual(order.Items.Count, 0);
    }

    [TestMethod]
    [TestCategory("Domain")]
    public void ShouldReturnTotalEqualsFiftyWhenOrderIsValid()
    {
      var order = new Order(_customer, 10, _discount);
      order.AddItem(_product, 5);
      Assert.AreEqual(order.Total(), 50);
    }

    [TestMethod]
    [TestCategory("Domain")]
    public void ShouldReturnTotalEqualsSixtyWhenDiscountExpired()
    {
      var expiredDiscount = new Discount(10, DateTime.Now.AddDays(-5));
      var order = new Order(_customer, 10, expiredDiscount);
      order.AddItem(_product, 5);
      Assert.AreEqual(order.Total(), 60);
    }

    [TestMethod]
    [TestCategory("Domain")]
    public void Test9()
    {
      Assert.Fail();
    }

    [TestMethod]
    [TestCategory("Domain")]
    public void Test10()
    {
      Assert.Fail();
    }

    [TestMethod]
    [TestCategory("Domain")]
    public void Test11()
    {
      Assert.Fail();
    }

    [TestMethod]
    [TestCategory("Domain")]
    public void Test12()
    {
      Assert.Fail();
    }
  }
}