using Gestion_clinica.models;

public class CustomerRepository : ICustomerRepository
{
    private readonly List<Customer> _customers = new();

    public void Add(Customer customer)
    {
        _customers.Add(customer);
    }

    public void Delete(int id)
    {
        var customer = GetById(id);
        if (customer != null)
        {
            _customers.Remove(customer);
        }
    }

    public List<Customer> GetAll() => _customers;

    public Customer GetById(int id) => _customers.FirstOrDefault(c => c.Id == id);

    public void Update(Customer customer)
    {
        var existing = GetById(customer.Id);
        if (existing != null)
        {
            existing.Name = customer.Name;
            existing.Age = customer.Age;
            existing.Address = customer.Address;
            // Puedes actualizar también Pets y Appointments si lo deseas
        }
    }
}
