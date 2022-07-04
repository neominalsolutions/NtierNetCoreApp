using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseScaffoldApplication.Domain.Models
{
    public interface IRepository<T> 
    {
        Task CreateAsync(T item);
        Task<int> SaveAsync();
        Task<T> SelectAsync(int id);
        Task<List<T>> SelectManayAsync();


        void Create(T item);
        void Delete(int id);
        void Update(T item);

        T Select(int id);
        List<T> SelectMany();

        int Save();
    }
}
