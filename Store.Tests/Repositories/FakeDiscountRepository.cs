using Store.Domain.Entities;
using Store.Domain.Repositories.Interfaces;

namespace Store.Tests.Repositories
{
  public class FakeDiscountRepository : IDiscountRepository
  {
    public Discount Get(string code)
    {
      throw new NotImplementedException();
    }
  }
} 