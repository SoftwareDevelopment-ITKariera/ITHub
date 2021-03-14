using System;
using System.Collections.Generic;
using System.Text;

namespace DreamJourney.Services.Contracts
{
    public interface IBaseService<T>
    {
        List<T> GetAll();
        T GetById(int id);
        void Insert(T item);
        void Update(T item);
        void Delete(int id);
    }
}
