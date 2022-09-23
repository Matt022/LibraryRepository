using Library.Core.Abstractions.Services;
using Library.UI.Base;
using Library.UI.Helpers;
using Library.UI.Pages.Rentals.Queue;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.UI.Pages.Rentals
{
    internal class RentalsPage : MenuPageBase
    {
        private const string PAGE_HEADER = "Rentals page";

        public RentalsPage(Application app) : base(PAGE_HEADER, app)
        {
            InitializeMenu();
        }

        public override void Display()
        {
            base.Display();

            this.Menu.Display();
        }

        private void InitializeMenu()
        {
            this.Menu.Add(1, "Rent a title", () => this.Application.NavigateTo<RentATitlePage>());
            this.Menu.Add(2, "Return a title", () => this.Application.NavigateTo<ReturnTitlePage>());
            this.Menu.Add(3, "Prolong the rental", () => this.Application.NavigateTo<ProlongRentalPage>());
            this.Menu.Add(4, "Show all rentals", () => this.Application.NavigateTo<AllRentalsPage>());
            this.Menu.Add(5, "Show rentals past due", () => this.Application.NavigateTo<PastDueRentalsPage>());
            this.Menu.Add(6, "Show Queue", () => this.Application.NavigateTo<QueuePage>());
            this.Menu.Add(7, "Back", () => this.Application.NavigateBack());
        }
    }
}
