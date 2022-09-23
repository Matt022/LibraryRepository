using Library.Core.Abstractions;
using Library.Core.Abstractions.Repositories;
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
    internal class ProlongRentalPage : MenuPageBase
    {
        private const string PAGE_HEADER = "Prolong rental";

        private readonly IRentalEntryService _rentalService;

        private readonly IMemberRepository _memberRepository;

        private Menu _chooseRentalItemMenu;

        public ProlongRentalPage(Application app) : base(PAGE_HEADER, app)
        {
            this._rentalService = app.Services.GetService<IRentalEntryService>();
            this._memberRepository = app.Services.GetService<IMemberRepository>();
        }

        public override void Display()
        {
            InitializeUserMenu();

            this.Menu.Display();

            if (this._chooseRentalItemMenu is not null)
            {
                Console.Clear();
                this._chooseRentalItemMenu.Display();

            }


            InputHelper.ReadKey("Press any key to return to rentals menu...");
            this.Application.NavigateBack();

        }


        private void InitializeUserMenu()
        {
            var members = _memberRepository.GetAll().ToList();
            this.Menu = new Menu();

            for (int i = 0; i < members.Count; i++)
            {
                var member = members[i];
                this.Menu.Add(i + 1, $"{member.ToString()}", () => InitializeItemsMenu(member));
            }
        }

        private void InitializeItemsMenu(Member member)
        {
            var items = _rentalService.GetByUnreturnedMember(member.Id);

            if(items.Count == 0)
            {
                OutputHelper.WriteLine("No rentals to prolong...");
                return;
            }


            for (int i = 0; i < items.Count; i++)
            {
                var item = items[i];
                _chooseRentalItemMenu = new Menu();
                _chooseRentalItemMenu.Add(i + 1, $"{item.ToString()}", () => ProlongRental(item));
            }
        }

        private void ProlongRental(RentalEntry entry)
        {
            if (!_rentalService.CanProlongRental(entry, out var error))
            {
                OutputHelper.WriteLine(error, ConsoleColor.Red);
                return;
            }
            _rentalService.ProlongRental(entry);

            OutputHelper.WriteLine("Rental prolonged successfully....", ConsoleColor.Green);
        }
    }
}
