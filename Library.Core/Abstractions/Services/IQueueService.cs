using Library.Core.Entities;
using Library.Core.Events;


namespace Library.Core.Abstractions.Services
{
    public interface IQueueService
    {
        QueueItem AddToQueue(Title title, Member member);
        void MarkAsResolved(QueueItem item);

        List<QueueItem> GetAllItems();

        void OnTitleReturned(object sender, TitleReturnedEventArgs args);


        List<QueueItem> GetItems(int titleId, bool onlyPendingItems);

    }
}
