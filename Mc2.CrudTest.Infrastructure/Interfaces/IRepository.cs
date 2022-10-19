using Mc2.CrudTest.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Infrastructure.Interfaces
{
    public interface IRepository
    {
        public Task<T> GetByIdAsync<T>(int id) where T : BaseEntity;
        public Task<List<T>> ListAsync<T>() where T : BaseEntity;
        public Task<T> AddAsync<T>(T entity) where T : BaseEntity;
        public Task<bool> UpdateAsync<T>(T entity) where T : BaseEntity;
        public Task<bool> DeleteAsync<T>(T entity) where T : BaseEntity;
    }
}
