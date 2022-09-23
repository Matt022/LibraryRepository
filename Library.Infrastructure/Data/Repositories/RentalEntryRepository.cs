using Library.Core.Abstractions;
using Library.Core.Abstractions.Repositories;
using Library.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.Data.Repositories
{
    public class RentalEntryRepository : IRentalEntryRepository
    {
        public RentalEntryRepository(LibraryContext context)
        {
            _context = context;
        }

        private readonly LibraryContext _context;

        public RentalEntry Create(RentalEntry entity)
        {
            var result = this._context.RentalEntries.Add(entity);
            this._context.SaveChanges();

            return result.Entity;
        }

        public RentalEntry Delete(int id)
        {
            var entity = this.GetById(id);

            if (entity == null) return null;

            var result = this._context.RentalEntries.Remove(entity);
            this._context.SaveChanges();

            return result.Entity;

        }

        public IEnumerable<RentalEntry> GetAll()
        {
            return this._context.RentalEntries.Include(e => e.Title).Include(e => e.Member);
        }


        public RentalEntry GetById(int id)
        {
            var result = this._context.RentalEntries.FirstOrDefault(b => b.Id == id);

            return result;
        }

        public void Update(int id, RentalEntry entity)
        {
            this._context.RentalEntries.Update(entity);
            this._context.SaveChanges();
        }

        public IEnumerable<RentalEntry> Find(Expression<Func<RentalEntry, bool>> expression)
        {
            return this._context.RentalEntries.Where(expression).Include(t => t.Title).Include(e => e.Member);
        }
    }
}
