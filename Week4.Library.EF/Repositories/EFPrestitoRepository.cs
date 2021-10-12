using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Week4.Library.Core;
using Week4.Library.Core.Interfaces;
using Week4.Library.Core.Models;

namespace Week4.Library.EF.Repositories
{
    public class EFPrestitoRepository : IPrestitoRepository
    {
        private readonly LibraryContext libraryContext;

        public EFPrestitoRepository()
        {
            libraryContext = new LibraryContext();
        }


        public bool Add(Prestito item)
        {
            if (item == null)
            {
                return false;
            }
            libraryContext.Prestiti.Add(item);
            libraryContext.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            Prestito prestito = libraryContext.Prestiti.Find(id);
            libraryContext.Prestiti.Remove(prestito);
            libraryContext.SaveChanges();
            return true;
        }

        public Prestito EditById(DateTime reso, int idLibro)
        {
            var oldPrestito = libraryContext.Prestiti.FirstOrDefault(p => p.Id == idLibro);
            oldPrestito.DataReso = reso;
            libraryContext.SaveChanges();
            return oldPrestito;
        }

        public List<Prestito> Fetch()
        {
            return libraryContext.Prestiti.ToList();
        }

        public Prestito GetById(int id)
        {
            return libraryContext.Prestiti.FirstOrDefault(p => p.Id == id);
        }

        public bool Update(Prestito item)
        {
            var oldPrestito = libraryContext.Prestiti.FirstOrDefault(p => p.Id == item.Id);
            oldPrestito.Utente = item.Utente;
           
            libraryContext.SaveChanges();
            return true;
        }

   
    }
}
