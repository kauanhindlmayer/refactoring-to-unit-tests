using Store.Domain.Commands;
using Store.Domain.Repositories.Interfaces;
using Store.Tests.Repositories;

namespace Store.Domain.Handlers
{
  [TestClass]
  public class OrderHandlerTests
  {
    private readonly ICustomerRepository _customerRepository;
    private readonly IDeliveryFeeRepository _deliveryFeeRepository;
    private readonly IDiscountRepository _discountRepositoy;
    private readonly IProductRepository _productRepository;
    private readonly IOrderRepository _orderRepository;

    public OrderHandlerTests()
    {
      _customerRepository = new FakeCustomerRepository();
      _deliveryFeeRepository = new FakeDeliveryFeeRepository();
      _discountRepositoy = new FakeDiscountRepository();
      _productRepository = new FakeProductRepository();
      _orderRepository = new FakeOrderRepository();
    }

    [TestMethod]
    [TestCategory("Handlers")]
    public void ShouldNotCreateOrderWithoutCustomer()
    {
      Assert.Fail();
    }

    [TestMethod]
    [TestCategory("Handlers")]
    public void ShouldCreateOrderNormallyWhenCEPIsValid()
    {
      Assert.Fail();
    }

    [TestMethod]
    [TestCategory("Handlers")]
    public void ShouldCreateOrderNormallyWithoutPromocode()
    {
      Assert.Fail();
    }

    [TestMethod]
    [TestCategory("Handlers")]
    public void ShouldNotCreateOrderWithoutItems()
    {
      Assert.Fail();
    }

    [TestMethod]
    [TestCategory("Handlers")]
    public void ShouldNotCreateOrderWhenCommandIsInvalid()
    {
      Assert.Fail();
    }

    [TestMethod]
    [TestCategory("Handlers")]
    public void ShouldCreateOrderWhenCommandIsValid()
    {
      var command = new CreateOrderCommand();
      command.Customer = "";
      command.ZipCode = "13411080";
      command.PromoCode = "12345678";
      command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));
      command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));

      var handler = new OrderHandler(
        _customerRepository,
        _deliveryFeeRepository,
        _discountRepositoy,
        _productRepository,
        _orderRepository
      );

      handler.Handle(command);
      Assert.AreEqual(command.IsValid, true);
    }
  }
}