namespace Gestion_clinica.models
{
    public class Appointment
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Doctor { get; set; }

        public Appointment(int id, int patientId, DateTime date, string description, string doctor)
        {
            Id = id;
            PatientId = patientId;
            Date = date;
            Description = description;
            Doctor = doctor;
        }

        public override string ToString()
        {
            return $"Appointment #{Id}: {Date:dd/MM/yyyy HH:mm} - {Description} (Veterinary: {Doctor})";
        }
    }
}