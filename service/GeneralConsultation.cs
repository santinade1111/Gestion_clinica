using System;
using Gestion_clinica;

namespace Gestion_clinica.service
{
    public class GeneralConsultation : ServiceVeterinary
    {
        public override void Attend()
        {
            Console.WriteLine("Attending general consultation...");
        }


    public static void GeneralConsultationMethod()
        {
            var consulta = new GeneralConsultation();
            consulta.Attend();
        }
    }
}