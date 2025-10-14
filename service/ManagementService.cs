using Gestion_clinica.models;

public class ManagementService
{
    private readonly ICustomerRepository _customerRepo;
    private readonly IPetRepository _petRepo;
    private readonly IVeterinarianRepository _vetRepo;
    private readonly IAppointmentRepository _appointmentRepo;

    public ManagementService(ICustomerRepository customerRepo, IPetRepository petRepo, IVeterinarianRepository vetRepo, IAppointmentRepository appointmentRepo)
    {
        _customerRepo = customerRepo;
        _petRepo = petRepo;
        _vetRepo = vetRepo;
        _appointmentRepo = appointmentRepo;
    }

    // Registrar cliente: se genera un id internamente
    public void RegisterCustomer(string name, int age, string address)
    {
        var newCustomer = new Customer(GenerateId(), name, age, address);
        _customerRepo.Add(newCustomer);
    }
    public List<Customer> GetAllCustomers() => _customerRepo.GetAll();
    public void UpdateCustomer(Customer customer) => _customerRepo.Update(customer);
    public bool CustomerExists(int id)
    {
        return _customerRepo.GetById(id) != null;
    }
    public void DeleteCustomer(int id) => _customerRepo.Delete(id);

    public void RegisterPet(string name, int age, string specie, string race, string ownerName)
    {
        var pet = new Pet(name, age, specie, race, ownerName);
        _petRepo.Add(pet);

        // Vincular con el cliente dueño
        var owner = _customerRepo.GetAll().FirstOrDefault(c => c.Name.Equals(ownerName, StringComparison.OrdinalIgnoreCase));
        if (owner != null)
        {
            owner.Pets.Add(pet);
            _customerRepo.Update(owner);
        }
    }
    public List<Pet> GetAllPets() => _petRepo.GetAll();
    public void UpdatePet(Pet pet) => _petRepo.Update(pet);
    public void DeletePet(string name) => _petRepo.Delete(name);

    // Veterinarian
    public void RegisterVeterinarian(int id, string name, string specialty)
    {
        var vet = new Veterinarian(id, name, specialty);
        _vetRepo.Add(vet);
    }
    public List<Veterinarian> GetAllVeterinarians() => _vetRepo.GetAll();
    public void UpdateVeterinarian(Veterinarian vet) => _vetRepo.Update(vet);
    public void DeleteVeterinarian(int id) => _vetRepo.Delete(id);

    // Appointment
    public void ScheduleAppointment(int id, int customerId, DateTime date, string description, int vetId)
    {
        var vet = _vetRepo.GetById(vetId);
        var appointment = new Appointment(id, customerId, date, description, vet);

        _appointmentRepo.Add(appointment);

        var customer = _customerRepo.GetById(customerId);
        if (customer != null)
        {
            customer.Appointments.Add(appointment);
            _customerRepo.Update(customer);
        }
    }
    public List<Appointment> GetAllAppointments() => _appointmentRepo.GetAll();
    public void UpdateAppointment(Appointment appointment) => _appointmentRepo.Update(appointment);
    public void DeleteAppointment(int id) => _appointmentRepo.Delete(id);

    private int GenerateId()
    {
        return _customerRepo.GetAll().Count + 1;
    }
}
