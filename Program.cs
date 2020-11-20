using System;

namespace Giliberto.TestADO.NET
{
    class Program
    {
        static void Main(string[] args)
        {

            //Console.WriteLine("Quale area ti interessa? (2-3-5-6)");

            //int idArea = Int32.Parse(Console.ReadLine());

            //Connected.AgentiPerArea(idArea);


            Console.WriteLine("Inserisci i dati dell'agente (nome, cognome, dob, CF, anni servizio)");

            String nome = Console.ReadLine();
            String cognome = Console.ReadLine();
            DateTime dob = DateTime.Parse(Console.ReadLine());
            String CF = Console.ReadLine();
            int anni = Int32.Parse(Console.ReadLine());

            Connected.AggiungiAgente(nome, cognome, CF, dob, anni);



        }
    }
}
