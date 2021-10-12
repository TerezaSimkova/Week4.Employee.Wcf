using System;
using System.Collections.Generic;
using System.Linq;
using Week4.Library.Core;
using Week4.Library.Core.Interfaces;
using Week4.Library.EF.Repositories;

namespace Week4.Library.EF
{
    public class EFBookRepository : IBookRepository
    {
        private readonly LibraryContext libraryContext;

        public EFBookRepository()
        {
            libraryContext = new LibraryContext();
        }

        public bool Add(Book item)
        {
            if (item==null)
            {
                return false;
            }
            libraryContext.Books.Add(item);
            libraryContext.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            Book book = libraryContext.Books.Find(id);
            libraryContext.Books.Remove(book);
            libraryContext.SaveChanges();
            return true;
        }

        public List<Book> Fetch()
        {
            return libraryContext.Books.ToList();
        }

        public Book GetById(int id)
        {
            return libraryContext.Books.FirstOrDefault(b => b.Id == id);
        }

        public bool Update(Book item)
        {
            var oldBook= libraryContext.Books.FirstOrDefault(b => b.Id == item.Id);
            oldBook.Title = item.Title;
            oldBook.Author = item.Author;
            oldBook.Isbn = item.Isbn;
            libraryContext.SaveChanges();
            return true;
        }
    }
}
