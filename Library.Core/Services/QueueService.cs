using Library.Core.Abstractions.Repositories;
using Library.Core.Abstractions.Services;
using Library.Core.Entities;
using Library.Core.Events;


namespace Library.Core.Services
{
    public class QueueService : IQueueService
    {
        private readonly IQueueItemRepository _repository;

        private readonly IMessagingService _messagingService;

        public QueueService(IQueueItemRepository repo, IMessagingService messagingService)
        {
            this._repository = repo;
            this._messagingService = messagingService;

        }

        public QueueItem AddToQueue(Title title, Member member)
        {
            var queueItem = new QueueItem();

            queueItem.TitleId = title.Id;
            queueItem.MemberId = member.Id;
            queueItem.TimeAdded = DateTime.UtcNow;

            return this._repository.Create(queueItem);
        }

        public void MarkAsResolved(QueueItem item)
        {
            item.IsResolved = true;

            this._repository.Update(item.Id, item);
        }

        public List<QueueItem> GetAllItems()
        {
            return this._repository.GetAll().ToList();
        }

        public List<QueueItem> GetItems(int titleId, bool onlyPendingItems)
        {
            var items = this._repository.Find(i => i.TitleId == titleId).ToList();

            if (onlyPendingItems)
            {
                items = items.Where(i => i.IsResolved == false).ToList();
            }

            return items;
        }


        public void OnTitleReturned(object sender, TitleReturnedEventArgs args)
        {
            var queueItems = _repository.Find(i => i.TitleId == args.Title.Id && i.IsResolved == false).ToList();


            if (queueItems is not null && queueItems.Count() > 0)
            {
                var title = queueItems.OrderBy(i => i.TimeAdded).LastOrDefault();
                NotifyMember(title);

                MarkAsResolved(title);

            }

        }

        private void NotifyMember(QueueItem item)
        {
            var subject = $"Title {item.Title.Name} available!";
            var message = $"Dear Mr/Mrs {item.Member.LastName},{Environment.NewLine}\tthe title {item.Title.Name} is available for rent!{Environment.NewLine}Best regards,\t The Library Team <3";

            _messagingService.SendMessage(item.MemberId, subject, message);
        }
    }
}
