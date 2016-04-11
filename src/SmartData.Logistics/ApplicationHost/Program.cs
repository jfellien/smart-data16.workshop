using System;
using System.Collections.Generic;
using ApplicationContracts;
using ApplicationQueries;
using ReadModel;

namespace ApplicationHost
{
    class Program
    {
        private static Queries _queries;

        static void Main(string[] args)
        {
            Bootstrap();

            var keyPressed = Menus.MainMenu().Key;

            while (keyPressed != ConsoleKey.X)
            {
                switch (keyPressed)
                {
                    case ConsoleKey.P: // Produkte ansehen
                        var products = _queries.Products.All();
                        Show(products);
                        break;
                    case ConsoleKey.L: // Lager ermitteln
                        var postZip = Menus.EnterYourPostZip();
                        var store = _queries.Stores.For(postZip);
                        Show(store);
                        break;
                    case ConsoleKey.T: // Termin finden
                        var deliveryRequest = Menus.EnterYourRequest();
                        var deliverySuggestions = _queries.Deliveries.SuggestionsFor(deliveryRequest);
                        Show(deliverySuggestions);
                        break;
                }

                keyPressed = Menus.MainMenu().Key;
            }

            Console.WriteLine(new String('+', 70));
            Console.WriteLine("\tAPPLIKATION BEENDET");
            Console.WriteLine(new String('+', 70));
        }

        private static void Show(IEnumerable<DeliverySuggestion> suggestions)
        {
            Console.WriteLine();

            Console.WriteLine(new String('+', 70));
            Console.WriteLine("\tVERFÜGBARE TERMINE");
            Console.WriteLine(new String('+', 70));

            Console.WriteLine();

            foreach (var suggestion in suggestions)
            {
                Console.WriteLine("{0}", suggestion.Date);
            }

            Console.WriteLine();
            Console.WriteLine("Weiter mit <ENTER>");
            Console.ReadLine();
        }

        private static void Show(Store store)
        {
            Console.WriteLine();

            Console.WriteLine(new String('+', 70));
            Console.WriteLine("\tZUSTÄNDIGES LAGER");
            Console.WriteLine(new String('+', 70));

            Console.WriteLine();

            Console.WriteLine("ID\t\tNAME");

            Console.WriteLine("{0}\t\t{1}", store.Id, store.Name);
            
            Console.WriteLine();
            Console.WriteLine("Weiter mit <ENTER>");
            Console.ReadLine();
        }

        private static void Show(IEnumerable<Product> products)
        {
            Console.WriteLine();

            Console.WriteLine(new String('+', 70));
            Console.WriteLine("\tVERFÜGBARE PRODUKTE");
            Console.WriteLine(new String('+', 70));

            Console.WriteLine();

            Console.WriteLine("ID\t\tNAME\t\tPREIS");

            foreach (var product in products)
            {
                Console.WriteLine("{0}\t\t{1}\t\t{2}", product.Id, product.Name, product.Price);
            }

            Console.WriteLine();
            Console.WriteLine("Weiter mit <ENTER>");
            Console.ReadLine();
        }

        static void Bootstrap()
        {
            var productsQueries = new ProductQueries();
            var storesQueries = new StoreQueries();
            var deliveryQueries = new DeliveryQueries();

            _queries = new Queries(productsQueries, storesQueries, deliveryQueries);
        }
    }
}
