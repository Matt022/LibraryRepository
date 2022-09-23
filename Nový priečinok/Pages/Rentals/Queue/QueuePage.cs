using Library.Core.Abstractions.Services;
using Library.Core.Entities;
using Library.UI.Base;
using Library.UI.Helpers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.UI.Pages.Rentals.Queue
{
    internal class QueuePage : PageBase
    {
        private const string PAGE_HEADER = "Queue";

        private readonly IQueueService _queueItemService;

        public QueuePage(Application app) : base(PAGE_HEADER, app)
        {
            this._queueItemService = app.Services.GetService<IQueueService>();
        }

        public override void Display()
        {
            base.Display();

            DisplayAllQueueItems();

            InputHelper.ReadKey("Press any key to continue to Rentals Menu...");

            this.Application.NavigateBack();
            
        }

        private void DisplayAllQueueItems()
        {
            var items = GetQueueItems();

            var sb = new StringBuilder();

            foreach (var item in items)
            {
                sb.AppendLine(item.ToString());
            }

            OutputHelper.WriteLine(sb.ToString());
        }

        private List<QueueItem> GetQueueItems()
        {
            return this._queueItemService.GetAllItems();
        }
    }
}
