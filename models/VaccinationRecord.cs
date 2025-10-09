namespace Gestion_clinica.models
{
    public class VaccinationRecord
    {
        public string VaccineName { get; set; }
        public DateTime DateApplied { get; set; }

        public VaccinationRecord(string vaccineName, DateTime dateApplied)
        {
            VaccineName = vaccineName;
            DateApplied = dateApplied;
        }
    }
}