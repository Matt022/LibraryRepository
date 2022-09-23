using Library.Core.Base;
using System.Linq.Expressions;

namespace Library.Core.Abstractions.Repositories
{
    public interface IRepository<T> where T : EntityBase
    {
        IEnumerable<T> GetAll();

        T GetById(int id);

        T Delete(int id);

        void Update(int id, T entity);

        T Create(T entity);

        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
    }
}
