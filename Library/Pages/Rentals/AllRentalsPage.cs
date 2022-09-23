using Library.Core.Abstractions;
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

namespace Library.UI.Pages.Rentals
{
    internal class AllRentalsPage : MenuPageBase
    {
        private const string PAGE_HEADER = "All rentals";

        public AllRentalsPage(Application app) : base(PAGE_HEADER,app)
        {
            this._rentalEntryService = app.Services.GetService<IRentalEntryService>();
        }

        private readonly IRentalEntryService? _rentalEntryService;

        public override void Display()
        {
            base.Display();

            DisplayAllRentalEntries();

            InputHelper.ReadKey("Press any key to return to Rentals page...");

            this.Application.NavigateBack();
        }

        private void DisplayAllRentalEntries()
        {
            var entries = GetAllRentalEntries();
            var sb = new StringBuilder();   

            foreach (var entry in entries)
            {
                sb.AppendLine(entry.ToString());
            }

            OutputHelper.WriteLine(sb.ToString());


        }

        private List<RentalEntry> GetAllRentalEntries()
        {
            return _rentalEntryService.GetAllEntries();
        }
    }
}
