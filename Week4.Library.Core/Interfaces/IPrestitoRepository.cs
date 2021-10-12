using System;
using System.Collections.Generic;
using System.Text;
using Week4.Library.Core.Models;

namespace Week4.Library.Core.Interfaces
{
    public interface IPrestitoRepository : IRepository<Prestito>
    {
        Prestito EditById(DateTime reso, int idLibro);
    }
}
