using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace Appplication.Common.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? include = null);
        T Get(Expression<Func<T, bool>>? filter = null, string? includeProperties = null);
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
    }
}