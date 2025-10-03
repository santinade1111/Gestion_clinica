using System;

namespace Gestion_clinica
{
    public class GeneralConsultation : ServiceVeterinary
    {
        public override void Attend()
        {
            Console.WriteLine("Attending general consultation...");
        }
    }

    public class Vaccination : ServiceVeterinary
    {
        public override void Attend()
        {
            Console.WriteLine("Applying vaccination...");
        }
    }
}
