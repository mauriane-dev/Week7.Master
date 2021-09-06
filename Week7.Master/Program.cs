using System;

namespace Week7.Master
{
    class Program
    {
        static void Main(string[] args)
        {
            bool continua = true;
            while (continua)
            {
                int scelta = SchermoMenu();
                continua = AnalizzaScelta(scelta);
            }
        }

        private static int SchermoMenu()
        {
            Console.WriteLine("******************Menu****************");
            //Funzionalità su Corsi
            Console.WriteLine("\nFunzionalità CORSI");
            Console.WriteLine("1. Visualizza Corsi");
            Console.WriteLine("2. Inserisci nuovo Corso");
            Console.WriteLine("3. Modifica Corso");
            Console.WriteLine("4. Elimina Corso");
            //Funzionalità su Docenti
            Console.WriteLine("\nFunzionalità Docenti");
            Console.WriteLine("5. Visualizza Docenti");
            Console.WriteLine("6. Inserisci nuovo Docente");
            Console.WriteLine("7. Modifica Docente");
            Console.WriteLine("8. Elimina Docente");
            //Funzionalità su Lezioni
            Console.WriteLine("\nFunzionalità Lezioni");
            Console.WriteLine("9. Visualizza elenco delle lezioni completo");
            Console.WriteLine("10. Inserimento nuova lezione");
            Console.WriteLine("11. Modifica lezione");//per semplicità solo modifica Aula
            Console.WriteLine("12. Elimina lezione");
            Console.WriteLine("13. Visualizza le Lezioni di un Corso ricercando per Codice del Corso");
            Console.WriteLine("14. Visualizza le Lezioni di un Corso ricercando per Nome del Corso");
            //Funzionalità su Studenti
            Console.WriteLine("\nFunzionalità Studenti");
            Console.WriteLine("15. Visualizza l'elenco completo degli studenti");
            Console.WriteLine("16. Inserimento nuovo Studente");
            Console.WriteLine("17. Modifica Studente");//per semplicità solo email
            Console.WriteLine("18. Elimina Studente");
            Console.WriteLine("19. Visualizza l'elenco degli studenti iscritti ad un corso");

            //Exit
            Console.WriteLine("\n0. Exit");
            Console.WriteLine("********************************************");
            
            
            int scelta;
            Console.Write("Inserisci scelta: ");
            while (!int.TryParse(Console.ReadLine(), out scelta) || scelta < 0 || scelta > 19)
            {
                Console.Write("\nScelta errata. Inserisci scelta corretta: ");
            }
            return scelta;

        }
        private static bool AnalizzaScelta(int scelta)
        {
            throw new NotImplementedException();
        }

    }
}
