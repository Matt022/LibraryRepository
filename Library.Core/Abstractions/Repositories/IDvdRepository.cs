using Library.Core.Entities;

namespace Library.Core.Abstractions.Repositories
{
    public interface IDvdRepository : IRepository<Dvd>
    {
        bool IsDvdAvailable(int id);
    }
}
