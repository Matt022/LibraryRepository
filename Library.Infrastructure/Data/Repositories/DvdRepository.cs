using Library.Core.Abstractions.Repositories;
using Library.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.Data.Repositories
{
    public class DvdRepository : IDvdRepository
    {
        private readonly LibraryContext _context;
        public DvdRepository(LibraryContext context)
        {
            _context = context;
        }


        public Dvd Create(Dvd entity)
        {
            var result = this._context.Dvds.Add(entity);
            this._context.SaveChanges();

            return result.Entity;
        }

        public Dvd Delete(int id)
        {
            var entity = this._context.Dvds.FirstOrDefault(b => b.Id == id);

            if (entity == null) return null;

            var result = this._context.Dvds.Remove(entity);
            this._context.SaveChanges();

            return result.Entity;

        }

        public IEnumerable<Dvd> GetAll()
        {
            return this._context.Dvds;
        }

        public Dvd GetById(int id)
        {
            var result = this._context.Dvds.FirstOrDefault(b => b.Id == id);

            return result;
        }

        public void Update(int id, Dvd entity)
        {
            this._context.Dvds.Update(entity);
            this._context.SaveChanges();
        }

        public IEnumerable<Dvd> Find(Expression<Func<Dvd, bool>> expression)
        {
            return this._context.Dvds.Where(expression);
        }

        public bool IsDvdAvailable(int id)
        {
            var entity = GetById(id);

            if (entity.AvailableCopies > 0)
            {
                return true;
            } else
            {
                return false;
            }


        }
    }
}
