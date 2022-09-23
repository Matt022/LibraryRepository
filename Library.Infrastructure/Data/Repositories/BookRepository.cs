using Library.Core.Abstractions.Repositories;
using Library.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Library.Infrastructure.Data.Repositories
{
    public class BookRepository : IBookRepository
    {
        public BookRepository(LibraryContext context)
        {
            _context = context;
        }

        private readonly LibraryContext _context;

        public Book Create(Book entity)
        {
            var result = this._context.Book.Add(entity);
            this._context.SaveChanges();

            return result.Entity;
        }

        public Book Delete(int id)
        {
            var entity = this.GetById(id);

            if (entity == null) return null;

            var result = this._context.Book.Remove(entity);
            this._context.SaveChanges();

            return result.Entity;

        }

        public IEnumerable<Book> GetAll()
        {
            return this._context.Book;
        }


        public Book GetById(int id)
        {
            var result = this._context.Book.FirstOrDefault(b => b.Id == id);

            return result;
        }

        public void Update(int id, Book entity)
        {
            this._context.Book.Update(entity);
            this._context.SaveChanges();
        }
        
        public IEnumerable<Book> Find(Expression<Func<Book, bool>> expression)
        {
            return this._context.Book.Where(expression);
        }

        public bool IsBookAvailable(int id)
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
