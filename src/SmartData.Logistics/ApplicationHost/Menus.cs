using System;
using ApplicationContracts;
using ApplicationContracts.Queries;

namespace ApplicationHost
{
    class Menus
    {
        public static ConsoleKeyInfo MainMenu()
        {
            Console.Clear();

            Console.WriteLine(new String('+', 70));
            Console.WriteLine("\tLIEFERTERMIN FINDEN");
            Console.WriteLine(new String('+', 70));

            Console.WriteLine();

            Console.WriteLine("\tP - Produkte anzeigen");
            Console.WriteLine("\tL - Zuständiges Lager anzeigen");
            Console.WriteLine("\tT - Termin vorschlagen");
            Console.WriteLine("\tX - Applikation beenden");
            Console.WriteLine(new String('-', 70));
            Console.Write("Ihre Auswahl:");
            return Console.ReadKey();
        }

        public static string EnterYourPostZip()
        {
            Console.Clear();

            Console.WriteLine(new String('+', 70));
            Console.WriteLine("\tZUSTÄNDIGES LAGER ANZEIGEN");
            Console.WriteLine(new String('+', 70));

            Console.WriteLine();

            Console.Write("Bitte geben Sie Ihre Postleitzahl ein:");

            return Console.ReadLine();

        }

        public static DeliveryRequest EnterYourRequest()
        {
            Console.Clear();

            Console.WriteLine(new String('+', 70));
            Console.WriteLine("\tANFRAGE ERSTELLEN");
            Console.WriteLine(new String('+', 70));

            Console.WriteLine();

            Console.Write("Bitte geben Sie ID des gewünschten Produktes ein:");

            var productId = int.Parse(Console.ReadKey().KeyChar.ToString());
            
            Console.WriteLine();

            Console.Write("Bitte geben Sie nun noch Ihre Postleitzahl ein:");

            var postZip = Console.ReadLine();

            return new DeliveryRequest(productId, postZip);
        }
    }
}