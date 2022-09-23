using Library.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Abstractions.Repositories
{
    public interface IQueueItemRepository : IRepository<QueueItem>
    {
    }
}
