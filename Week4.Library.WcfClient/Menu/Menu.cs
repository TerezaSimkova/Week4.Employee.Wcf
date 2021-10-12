using System;
using System.Collections.Generic;
using System.Linq;
using Week4.Library.Core;
using Week4.Library.Core.Models;
//using Week4.Library.WcfClient.ServiceReferenceLibrary;

namespace Week4.Library.WcfClient
{
    public class Menu
    {

        internal static void Start()
        {
            bool continua = true;
            int scelta;
            while (continua)
            {

                Console.WriteLine("***Library***\n");

                Console.WriteLine("Premi 1. per vedere tutti i libri.");
                Console.WriteLine("Premi 2. per eliminare un libro.");
                Console.WriteLine("Premi 3. per aggiungere un libro.");
                Console.WriteLine("Premi 4. per modificare un libro.");
                Console.WriteLine("Premi 5. per prestare libro.");
                Console.WriteLine("Premi 6. per rendere libro.");
                Console.WriteLine("Premi 0. per uscire.");

                do
                {
                    Console.WriteLine("Scegli un opzione:\n");

                } while (!int.TryParse(Console.ReadLine(), out scelta) || scelta < 0 || scelta > 6);

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
                    case 5:
                        BorrowBook();
                        break;
                    case 6:
                        ReturnBook();
                        break;
                    case 0:
                        Console.WriteLine("***Arrivederci***\n");
                        continua = false;
                        break;

                }
            }
        }

        private static void ReturnBook()
        {
            ServiceReferenceLibrary.LibraryServiceClient library = new ServiceReferenceLibrary.LibraryServiceClient();

            var prestiti = library.FetchPrestiti();
            foreach (var p in prestiti)
            {
                Console.WriteLine(p.Print());
            }
            DateTime reso = new DateTime();
            do
            {
                Console.WriteLine("\nInserisci Data di oggi:\n");

            } while (!DateTime.TryParse(Console.ReadLine(), out reso));
            int idLibro;
            do
            {
                Console.WriteLine("Inserisci ID del libro che rendi:\n");

            } while (!int.TryParse(Console.ReadLine(), out idLibro));
            var prestitoDaRendere = library.UpdateDataReso(reso, idLibro);
            if (prestitoDaRendere != null)
            {
                Console.WriteLine("Il reso del libro ricevuto con successo!\n");
            }
            else
            {
                Console.WriteLine("Non è stato possibile effetuare il reso!\n");
            }
        }

        private static void BorrowBook()
        {
            ServiceReferenceLibrary.LibraryServiceClient library = new ServiceReferenceLibrary.LibraryServiceClient();

            //Insert del prestito
            int idLibro;
            string utente = string.Empty;
            DateTime prestito = DateTime.Now;
            //DateTime reso = new DateTime().Date;

            Prestito newPrestito = new Prestito();

            var libri = library.FetchBooks();
            foreach (var l in libri)
            {
                Console.WriteLine(l.Print());
            }

            do
            {
                Console.WriteLine("Indserisci ID del libro che vuoi prendere:\n");

            } while (!int.TryParse(Console.ReadLine(), out idLibro));
            newPrestito.IdLibro = idLibro;

            do
            {
                Console.WriteLine("Nome utente:\n");
                utente = Console.ReadLine();

            } while (string.IsNullOrEmpty(utente));
            newPrestito.Utente = utente;

            do
            {
                Console.WriteLine("Data prestito:\n");

            } while (!DateTime.TryParse(Console.ReadLine(), out prestito)); //dalla data di oggi
            newPrestito.DataPrestito = prestito;

            //do
            //{
            //    Console.WriteLine("Data reso:\n");

            //} while (!DateTime.TryParse(Console.ReadLine(), out reso));
            //newPrestito.DataReso = reso;

            var crearePrestito = library.CreatePrestito(newPrestito);
            if (crearePrestito == true)
            {
                Console.WriteLine("Prestito confermato!\n");
            }
            else
            {
                Console.WriteLine("Non è stato possibile effetuare il prestito!\n");
            }
        }

        private static void ModifyBook()
        {
            ServiceReferenceLibrary.LibraryServiceClient library = new ServiceReferenceLibrary.LibraryServiceClient();

            var libri = library.FetchBooks();
            foreach (var l in libri)
            {
                Console.WriteLine(l.Print());
            }
            int idScelto;
            do
            {
                Console.WriteLine("Scegli ID del libro da modificare:\n");

            } while (!int.TryParse(Console.ReadLine(), out idScelto));
            Book bookToUpdate = library.GetByIdBook(idScelto);

            string isbn = string.Empty;
            string title = string.Empty;
            string author = string.Empty;
            do
            {
                Console.WriteLine("Nuovo ISBN del libro:");
                isbn = Console.ReadLine();
            } while (string.IsNullOrEmpty(isbn));

            var isJustNumer = Check(isbn);
            if (isJustNumer == true)
            {
                bookToUpdate.Isbn = isbn;
            }
            else
            {
                Console.WriteLine("Inserire solo numeri!\n");
            }
            do
            {
                Console.WriteLine("Nuovo titolo del libro:\n");
                title = Console.ReadLine();

            } while (string.IsNullOrEmpty(title));
            bookToUpdate.Title = title;
            do
            {
                Console.WriteLine("Nuovo l´autore del libro:\n");
                author = Console.ReadLine();

            } while (string.IsNullOrEmpty(author));
            bookToUpdate.Author = author;
            var updateBook = library.EditBook(bookToUpdate);
            if (updateBook == true)
            {
                Console.WriteLine("Libro modificato con successo!\n");
            }
            else
            {
                Console.WriteLine("Non è stato possibile modificare il libro!\n");
            }

        }

        private static void AddBook()
        {
            ServiceReferenceLibrary.LibraryServiceClient library = new ServiceReferenceLibrary.LibraryServiceClient();


            string isbn = string.Empty;
            string title = string.Empty;
            string author = string.Empty;
            Book newBook = new Book();
            do
            {
                Console.WriteLine("Scrivi il codice ISBN del libro:\n");
                isbn = Console.ReadLine();

            } while (string.IsNullOrEmpty(isbn));

            var isJustNumer = Check(isbn);
            if (isJustNumer == true)
            {
                newBook.Isbn = isbn;
            }
            else
            {
                Console.WriteLine("Inserire solo numeri!\n");
            }
            do
            {
                Console.WriteLine("Scrivi il titolo del libro:\n");
                title = Console.ReadLine();

            } while (string.IsNullOrEmpty(title));
            newBook.Title = title;
            do
            {
                Console.WriteLine("Scrivi l´autore del libro:\n");
                author = Console.ReadLine();

            } while (string.IsNullOrEmpty(author));
            newBook.Author = author;

            var addBook = library.CreateBook(newBook);
            if (addBook == true)
            {
                Console.WriteLine("Libro inserito con successo!\n");
            }
        }

        private static bool Check(string isbn)
        {
            return isbn.All(char.IsDigit);
        }

        private static void DeleteBook()
        {
            ServiceReferenceLibrary.LibraryServiceClient library = new ServiceReferenceLibrary.LibraryServiceClient();

            int idLibro;
            do
            {
                Console.WriteLine("Scegli Id del libro da eliminare:\n");

            } while (!int.TryParse(Console.ReadLine(), out idLibro));

            var bookToDelete = library.DeleteBook(idLibro);
            if (bookToDelete == true)
            {
                Console.WriteLine($"Libro eliminato con successo!.");
            }
            else
            {
                Console.WriteLine($"Non è stato possibile eliminare il libro!.");
            }

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

//int scelta;
//bool continua = true;
//while (continua)
//{
//    do
//    {
//        Console.WriteLine("Cosa vuoi modificare?\n");
//        Console.WriteLine("Premi 1. Codice ISBN del libro");
//        Console.WriteLine("Premi 2. Titolo del libro");
//        Console.WriteLine("Premi 3. Autore del libro");
//        Console.WriteLine("Premi 0 per uscire.\n");


//    } while (!int.TryParse(Console.ReadLine(), out scelta));

//}
// switch (scelta)
//{
//    case 1:
//        string isbn = string.Empty;
//        Book bookUpdate = new Book();
//        do
//        {
//            Console.WriteLine("Nuovo ISBN del libro:");
//            isbn = Console.ReadLine();
//        } while (string.IsNullOrEmpty(isbn));

//        var isJustNumer = Check(isbn);
//        if (isJustNumer == true)
//        {
//            bookUpdate.Isbn = isbn;
//            library.EditBook(bookUpdate);
//        }
//        else
//        {
//            Console.WriteLine("Inserire solo numeri!\n");
//        }
//        break;
//    case 2:
//        break;
//    case 3:
//        break;
//    case 0:
//        Console.WriteLine("***Arrivederci***");
//        continua = false;
//        break;
//}