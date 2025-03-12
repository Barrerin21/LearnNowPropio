using LearnNow.Class.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnNow.Class
{
    public interface IRepositoryGeneric<T> where T : IEntity
    {
        Task<int> Create(T entity);
        Task Delete(int id);
        Task<ICollection<T>> GetAll();
        Task<T> GetById(int id);
        Task Update(T entity);
    }
}
