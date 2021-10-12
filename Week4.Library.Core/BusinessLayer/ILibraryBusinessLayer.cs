using System;
using System.Collections.Generic;
using System.Text;
using Week4.Library.Core.Models;

namespace Week4.Library.Core.BusinessLayer
{
    public interface ILibraryBusinessLayer
    {
        //metodi del business layer
        bool AddBook(Book newBook);
        bool DeleteBook(int idBook);
        bool EditBook(Book editBook);
        List<Book> FetchBooks();
        bool AddPrestito(Prestito newPrestito);
        bool DeletePrestito(int idPrestito);
        bool EditPrestito(Prestito newPrestito);
        List<Prestito> FetchPrestiti();
    }
}
