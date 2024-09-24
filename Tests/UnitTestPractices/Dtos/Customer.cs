public class Customer : ICustomer
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; }

    public Customer()
    {

    }
    public Customer(int id, string name)
    {
        Id = id;
        Name = name;
    }
    override public string ToString()
    {
        return $"Id {Id} Name : {Name}";
    }
}
public interface ICustomer
{
    public string Address { get; set; }
}