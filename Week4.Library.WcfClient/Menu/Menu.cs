using System;
using System.Collections.Generic;
using Week4.Library.Core;
//using Week4.Library.WcfClient.ServiceReferenceLibrary;

namespace Week4.Library.WcfClient
{
    public class Menu
    {
        
        internal static void Start()
        {

            Console.WriteLine("***Libreria***\n");

            Console.WriteLine("Premi 1. per vedere tutti i libri.");
            Console.WriteLine("Premi 2. per eliminare un libro.");
            Console.WriteLine("Premi 3. per aggiungere un libro.");
            Console.WriteLine("Premi 4. per modificare un libro.\n");

            int scelta;
            do
            {
                Console.WriteLine("Scegli un opzione:\n");

            } while (!int.TryParse(Console.ReadLine(), out scelta) || scelta > 0 || scelta < 4);

            switch (scelta)
            {
                case 1:
                    GetAllBooks();
                    break;
                case 2:
                    DeleteBook();
                    break;
                case 3:
                    AddBook();
                    break;
                case 4:
                    ModifyBook();
                    break;

            }

        }

        private static void ModifyBook()
        {
            throw new NotImplementedException();
        }

        private static void AddBook()
        {
            throw new NotImplementedException();
        }

        private static void DeleteBook()
        {
            throw new NotImplementedException();
        }

        private static void GetAllBooks()
        {
            ServiceReferenceLibrary.LibraryServiceClient library = new ServiceReferenceLibrary.LibraryServiceClient();

            var allBooks = library.FetchBooks();
            foreach (var b in allBooks)
            {
                Console.WriteLine(b.Print());
            }
        }
    }
}