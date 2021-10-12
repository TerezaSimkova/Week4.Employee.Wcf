using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Week4.Library.Core;
using Week4.Library.Core.BusinessLayer;
using Week4.Library.Core.Models;
using Week4.Library.EF;
using Week4.Library.EF.Repositories;

namespace Week4.Library.Wcf
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class LibraryService : ILibraryService
    {
        private ILibraryBusinessLayer libraryBL;

        public LibraryService()
        {
            libraryBL = new LibraryBusinessLayer(new EFBookRepository(), new EFPrestitoRepository());
        }

        public bool CreateBook(Book newBook)
        {
            if (newBook == null)
            {
                return false;
            }
            return libraryBL.AddBook(newBook);
        }

        public bool CreatePrestito(Prestito newPrestito)
        {
            if (newPrestito == null)
            {
                return false;
            }
            return libraryBL.AddPrestito(newPrestito);
        }

        public bool DeleteBook(int idBook)
        {
            if (idBook > 0)
            {
                return libraryBL.DeleteBook(idBook);
            }
            return false;
        }

        public bool DeletePrestito(int idPrestito)
        {
            if (idPrestito > 0)
            {
                return libraryBL.DeletePrestito(idPrestito);
            }
            return false;
        }

        public bool EditBook(Book editBook)
        {
            if (editBook == null)
            {
                return false;
            }
            return libraryBL.EditBook(editBook);
        }

        public bool EditPrestito(Prestito newPrestito)
        {
            if (newPrestito == null)
            {
                return false;
            }
            return libraryBL.EditPrestito(newPrestito);
        }

        public List<Book> FetchBooks()
        {
            return libraryBL.FetchBooks();
        }

        public List<Prestito> FetchPrestiti()
        {
            return libraryBL.FetchPrestiti();
        }
    }
}
