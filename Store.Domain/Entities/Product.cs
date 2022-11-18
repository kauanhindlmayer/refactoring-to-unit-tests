namespace Store.Domain.Entities
{
  public class Product : Entity
  {
    public Product(string title, decimal price, bool active)
    { 
      Title = title;
      Price = price;
      Active = active;
    }
    public string Title { get; set; }
    public decimal Price { get; set; }
    public bool Active { get; set; }

    public void ChangeInfo(string title, decimal price, bool active)
    { 
      Title = title;
      Price = price;
      Active = active;
    }
  }
}