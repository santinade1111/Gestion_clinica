using Gestion_clinica.models;

namespace Gestion_clinica.models
{
    public class Appointment
    {
        public int Id { get; set; }
        public int  CustomerId { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public Veterinarian? Veterinarian { get; set; }

        public Appointment(int id, int customerId, DateTime date, string description)
        {
            Id = id;
            CustomerId = customerId;
            Date = date;
            Description = description;
            Veterinarian = null;
        }

        public Appointment(int id, int customerId, DateTime date, string description, Veterinarian veterinarian)
        {
            Id = id;
            CustomerId = customerId;
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