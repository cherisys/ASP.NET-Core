using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Api.Global
{
    public interface IRepository<T> where T: EntityBase
    {
        Task Create(T entity);
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(Int64 Id);
        Task Delete(Int64 Id);
        Task Update(T entity);
    }
}
