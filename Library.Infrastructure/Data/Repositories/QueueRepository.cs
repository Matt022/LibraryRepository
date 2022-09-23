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
    public class QueueItemRepository : IQueueItemRepository
    {
        private readonly LibraryContext _context;
        public QueueItemRepository(LibraryContext context)
        {
            _context = context;
        }


        public QueueItem Create(QueueItem entity)
        {
            var result = this._context.QueueItems.Add(entity);
            this._context.SaveChanges();

            return result.Entity;
        }

        public QueueItem Delete(int id)
        {
            var entity = this._context.QueueItems.FirstOrDefault(b => b.Id == id);

            if (entity == null) return null;

            var result = this._context.QueueItems.Remove(entity);
            this._context.SaveChanges();

            return result.Entity;

        }

        public IEnumerable<QueueItem> GetAll()
        {
            return this._context.QueueItems;
        }

        public QueueItem GetById(int id)
        {
            var result = this._context.QueueItems.FirstOrDefault(b => b.Id == id);

            return result;
        }

        public void Update(int id, QueueItem entity)
        {
            this._context.QueueItems.Update(entity);
            this._context.SaveChanges();
        }

        public IEnumerable<QueueItem> Find(Expression<Func<QueueItem, bool>> expression)
        {
            return this._context.QueueItems.Where(expression).Include(i => i.Title).Include(i => i.Member);
        }

        
    }
}
