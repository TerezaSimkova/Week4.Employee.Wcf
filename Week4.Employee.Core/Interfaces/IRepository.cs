using System;
using System.Collections.Generic;
using System.Text;

namespace Week4.Employee.Core.Interfaces
{
    public interface IRepository<T>
    {
        List<T> Fetch();
        T GetById(int id);
        bool Add(T item);
        bool Update(int id);
        bool Delete(int id);
    }
}
