using Flunt.Notifications;
using Store.Domain.Commands;
using Store.Domain.Commands.Interfaces;
using Store.Domain.Entities;
using Store.Domain.Handlers.Interfaces;
using Store.Domain.Repositories.Interfaces;
using Store.Domain.Utils;

namespace Store.Domain.Handlers
{
  public class OrderHandler : Notifiable<Notification>, IHandler<CreateOrderCommand>
  {
    private readonly ICustomerRepository _customerRepository;
    private readonly IDeliveryFeeRepository _deliveryFeeRepository;
    private readonly IDiscountRepository _discountRepositoy;
    private readonly IProductRepository _productRepository;
    private readonly IOrderRepository _orderRepository;

    public OrderHandler(ICustomerRepository customerRepository, IDeliveryFeeRepository deliveryFeeRepository, IDiscountRepository discountRepositoy, IProductRepository productRepository, IOrderRepository orderRepository)
    {
      _customerRepository = customerRepository;
      _deliveryFeeRepository = deliveryFeeRepository;
      _discountRepositoy = discountRepositoy;
      _productRepository = productRepository;
      _orderRepository = orderRepository;
    }

    public ICommandResult Handle(CreateOrderCommand command)
    {
      // Fail Fast Validation
      command.Validate();
      if (command.IsValid)
        return new GenericCommandResult(false, "Pedido inválido", command.Notifications);

      var customer = _customerRepository.Get(command.Customer);

      var deliveryFee = _deliveryFeeRepository.Get(command.ZipCode);

      var discount = _discountRepositoy.Get(command.PromoCode);

      var products = _productRepository.Get(ExtractGuids.Extract(command.Items)).ToList();
      var order = new Order(customer,deliveryFee, discount);
      foreach (var item in command.Items)
      {
        var product = products.Where(x => x.Id == item.Product).FirstOrDefault();
        order.AddItem(product, item.Quantity);
      }

      AddNotifications(order.Notifications);

      if (!IsValid)
        return new GenericCommandResult(false, "Falha ao gerar o pedido", Notifications);

      _orderRepository.Save(order);
      return new GenericCommandResult(true, $"Pedido {order.Number} gerado com sucesso", order);
    }
  }
}