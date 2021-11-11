using System;
using System.Collections.Generic;
using System.Text;

namespace SomeRandomService.Generic
{
    public interface IRepository<T> where T : class
    {
        List<T> GetAll();
        T Add(T entity);
        void Delete(T entity);
        T Update(T entity);
    }

    public class DataStore<T> 
    {
        public T Data { get; set; }

        public void Print()
        {
            Console.WriteLine(Data);
        }
    }
}
