using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UserStore.Data.Interfaces
{
    public interface IRepository<T,S> where T : class
    {
        IQueryable<T> GetAll();
        T Get(S id);
        IQueryable<T> Find(Func<T, Boolean> predicate);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }
}
