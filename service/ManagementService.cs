public class ManagementService
{
    private readonly ICustomerRepository _customerRepo;
    private readonly IPetRepository _petRepository;
    private readonly IVeterinarianRepository _vetRepo;
    private readonly IAppointmentRepository _appointmentRepo;

    public ManagementService(ICustomerRepository customerRepo, IPetRepository petRepo, IVeterinarianRepository vetRepo, IAppointmentRepository appointmentRepo)
    {
        _customerRepo = customerRepo;
        _petRepository = petRepo;
        _vetRepo = vetRepo;
        _appointmentRepo = appointmentRepo;
        
    }

    public void RegisterCustomer(int id string name, int age, string address)
    {
        var newCustomer = new Customer { Id = GenerateId(), Name = name, Age = age, Address = address, Pets = new List<Pet>(), Appointments = new List<Appointment>()};
        _customerRepo.Add(newCustomer);
    }

    public List<Customer> GetAllCustomers() => _customerRepo.GetAll();

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

    // Veterinarian
    public void RegisterVeterinarian(int id, string name, string specialty)
    {
        var vet = new Veterinarian(id, name, specialty);
        _vetRepo.Add(vet);
    }

    public List<Veterinarian> GetAllVeterinarians() => _vetRepo.GetAll();

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

    private int GenerateId()
    {
        return _customerRepo.GetAll().Count + 1;
    }
}
