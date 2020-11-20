using System;

namespace Giliberto.TestADO.NET
{
    class Program
    {
        static void Main(string[] args)
        {


            //ESERCIZIO 10.1

            Console.WriteLine("Quale area ti interessa? (2-3-5-6)");

            int idArea = Int32.Parse(Console.ReadLine());

            switch (idArea)
            {
                case 2:
                case 3:
                case 5:
                case 6:
                    Connected.AgentiPerArea(idArea);
                    break;
                default:
                    Console.WriteLine("Area non esistente! Scegli tra 2, 3, 5 e 6.");
                    break;
            }


            // ESERCIZIO 10.2

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
