using models;

public class AppointmentRepository : IAppointmentRepository
{
    private readonly List<Appointment> _appointments = new();

    public void Add(Appointment appointment)
    {
        _appointments.Add(appointment);
    }

    public void Delete(int id)
    {
        var appointment = GetById(id);
        if (appointment != null)
        {
            _appointments.Remove(appointment);
        }
    }

    public List<Appointment> GetAll() => _appointments;

    public Appointment GetById(int id) => _appointments.FirstOrDefault(a => a.Id == id);

    public void Update(Appointment appointment)
    {
        var existing = GetById(appointment.Id);
        if (existing != null)
        {
            existing.Date = appointment.Date;
            existing.Description = appointment.Description;
            existing.Veterinarian = appointment.Veterinarian;
        }
    }
}
