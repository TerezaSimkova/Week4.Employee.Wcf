using System;
using System.Collections.Generic;
using System.Text;
using Week4.Library.Core.Interfaces;
using Week4.Library.Core.Models;

namespace Week4.Library.Core.BusinessLayer
{
    public class LibraryBusinessLayer : ILibraryBusinessLayer
    {
        private readonly IBookRepository bookRepo;
        private readonly IPrestitoRepository presRepo;
        public LibraryBusinessLayer(IBookRepository bookrepository, IPrestitoRepository prestitoRepository)
        {
            bookRepo = bookrepository;
            presRepo = prestitoRepository;
        }

        public bool AddBook(Book newBook)
        {
            if (newBook == null)
            {
                return false;
            }
            return bookRepo.Add(newBook); //da fare
        }

        public bool AddPrestito(Prestito newPrestito) //Prestito libro
        {
            if (newPrestito == null)
            {
                return false;
            }
            return presRepo.Add(newPrestito);
        }

        public bool DeleteBook(int idBook)
        {
            if (idBook <= 0)
            {
                return false;
            }
            Book bookToDelete = bookRepo.GetById(idBook);
            if (bookToDelete != null)
            {
                return bookRepo.Delete(bookToDelete.Id);
            }
            return false;
        }

        public bool DeletePrestito(int idPrestito)
        {
            if (idPrestito <= 0)
            {
                return false;
            }
            Prestito presToDelete = presRepo.GetById(idPrestito);
            if (presToDelete != null)
            {
                return presRepo.Delete(presToDelete.Id);
            }
            return false;
        }

        public bool EditBook(Book editBook)
        {
            if (editBook == null)
            {
                return false;
            }
            return bookRepo.Update(editBook);
        }

        public bool EditPrestito(Prestito newPrestito) // Resa del libro
        {
            if (newPrestito == null)
            {
                return false;
            }
            return presRepo.Update(newPrestito);
        }

        //TODO: Implementare
        public List<Book> FetchBooks()
        {
            return bookRepo.Fetch();
        }

        public List<Prestito> FetchPrestiti()
        {
            return presRepo.Fetch();
        }
    }
}
