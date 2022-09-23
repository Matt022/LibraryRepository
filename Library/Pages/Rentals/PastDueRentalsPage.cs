using Library.Core.Abstractions;
using Library.Core.Abstractions.Services;
using Library.UI.Base;
using Library.UI.Helpers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.UI.Pages.Rentals
{
    internal class PastDueRentalsPage : PageBase
    {
        private const string PAGE_HEADER = "Past due rentals";

        private readonly IRentalEntryService _rentalService;

        public PastDueRentalsPage(Application app) : base(PAGE_HEADER, app)
        {
            this._rentalService = app.Services.GetService<IRentalEntryService>();
        }

        public override void Display()
        {
            base.Display();

            DisplayPastDueRentals();

            InputHelper.ReadKey("Press any key to return to Rental page...");

            this.Application.NavigateBack();

        }

        public void DisplayPastDueRentals()
        {
            var entries = _rentalService.GetRentalEntriesPastDue();

            foreach (var entry in entries)
            {
                OutputHelper.WriteLine(entry.ToString());
            }
        }
    }
}
