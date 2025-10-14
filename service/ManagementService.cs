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

    public void RegisterPet(string name, int age, string specie, string race, int ownerId)
    {
        var pet = new Pet(name, age, specie, race, ownerId);
        _petRepo.Add(pet);

        // Vincular con el cliente dueño
        var owner = _customerRepo.GetAll().FirstOrDefault(c => c.Name.Equals(StringComparison.OrdinalIgnoreCase));
        if (owner != null)
        {
            owner.Pets.Add(pet);
            _customerRepo.Update(owner);
        }
    }
    public List<Pet> GetAllPets() => _petRepo.GetAll();
    public void UpdatePet(Pet pet) => _petRepo.Update(pet);
    public bool PetExists(int id)
    {
        return _petRepo.GetById(id) != null;
    }
    public void DeletePet(int id)
    {
        _petRepo.Delete(id);
    }
    public int GetPetCountByCustomer(int customerId)
    {
        var allPets = _petRepo.GetAll();
        return allPets.Count(p => p.OwnerId == customerId);
    }


    // Veterinarian
    public void RegisterVeterinarian(string name, string specialty)
    {
        var vet = new Veterinarian(name, specialty);
        _vetRepo.Add(vet);
    }
    public bool VeterinarianExists(int id)
    {
        return _vetRepo.VeterinarianExists(id);
    }
    public Veterinarian? GetVeterinarianById(int id)
    {
        return _vetRepo.GetById(id);
    }
    public List<Veterinarian> GetAllVeterinarians() => _vetRepo.GetAll();
    public void UpdateVeterinarian(Veterinarian vet) => _vetRepo.Update(vet);
    public void DeleteVeterinarian(int id) => _vetRepo.Delete(id);

    // Appointment
    public void ScheduleAppointment(int id, int customerId, DateTime date, string description, int vetId)
    {
        var customer = _customerRepo.GetById(customerId);
        if (customer == null)
        {
            Console.WriteLine("❌ No se encontró el cliente con ese ID.");
            return;
        }

        var vet = _vetRepo.GetById(vetId);
        if (vet == null)
        {
            Console.WriteLine("❌ No se encontró el veterinario con ese ID.");
            return;
        }

        var appointment = new Appointment(id, customerId, date, description, vet);

        // Guardar en repositorio principal
        _appointmentRepo.Add(appointment);

        // Asociar la cita al cliente
        customer.Appointments.Add(appointment);
        _customerRepo.Update(customer);

        // (Opcional) Si quieres también mantener citas del veterinario
        vet.Appointments.Add(appointment);
        _vetRepo.Update(vet);
    }

    public List<Appointment> GetAllAppointments() => _appointmentRepo.GetAll();
    public void UpdateAppointment(Appointment appointment) => _appointmentRepo.Update(appointment);
    public void DeleteAppointment(int id)
    {
        var appointment = _appointmentRepo.GetById(id);
        if (appointment == null) return;

        // Eliminar del cliente
        var customer = _customerRepo.GetById(appointment.CustomerId);
        customer?.Appointments.RemoveAll(a => a.Id == id);
        if (customer != null) _customerRepo.Update(customer);

        // Eliminar del veterinario
        var vet = appointment.Veterinarian;
        vet?.Appointments.RemoveAll(a => a.Id == id);
        if (vet != null) _vetRepo.Update(vet);

        // Finalmente, eliminar del repositorio principal
        _appointmentRepo.Delete(id);
    }


    private int GenerateId()
    {
        return _customerRepo.GetAll().Count + 1;
    }
}
