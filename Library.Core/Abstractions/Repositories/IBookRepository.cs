using Library.Core.Entities;


namespace Library.Core.Abstractions.Repositories
{
    public interface IBookRepository : IRepository<Book>
    {
        bool IsBookAvailable(int id);
    }
}
