namespace Gestion_clinica.models
{
    public class Appointment
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public Veterinarian? Veterinarian { get; set; }

        public Appointment(int id, int patientId, DateTime date, string description, string doctor)
        {
            Id = id;
            PatientId = patientId;
            Date = date;
            Description = description;
            Veterinarian = null;
        }

        public Appointment(int id, int patientId, DateTime date, string description, Veterinarian veterinarian)
        {
            Id = id;
            PatientId = patientId;
            Date = date;
            Description = description;
            Veterinarian = veterinarian;
        }

        public override string ToString()
        {
            var vetInfo = Veterinarian != null ? $"Veterinarian: {Veterinarian.Name}" : "No veterinarian assigned";
            return $"Appointment #{Id}: {Date:dd/MM/yyyy HH:mm} - {Description} ({vetInfo})";
        }
    }
}