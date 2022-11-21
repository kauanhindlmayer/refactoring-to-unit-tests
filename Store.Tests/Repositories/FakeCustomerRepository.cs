using Store.Domain.Entities;
using Store.Domain.Repositories.Interfaces;

namespace Store.Tests.Repositories
{
  public class FakeCustomerRepository : ICustomerRepository
  {
    public Customer Get(string document)
    {
      if (document == "1234567811")
        return new Customer("Bruce Wayne", "batman@dc.com");

      return null;
    }
  }
}