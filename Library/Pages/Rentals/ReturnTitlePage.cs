using Library.Core.Abstractions;
using Library.Core.Abstractions.Repositories;
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
    internal class ReturnTitlePage : MenuPageBase
    {
        private const string PAGE_HEADER = "Return title page";

        public ReturnTitlePage(Application app): base(PAGE_HEADER, app)
        {
            this._rentalEntryService = app.Services.GetService<IRentalEntryService>();
            this._memberRepository = app.Services.GetService<IMemberRepository>();
        }

        private readonly IRentalEntryService _rentalEntryService;
        private readonly IMemberRepository _memberRepository;
        private Menu _chooseMemberMenu = new Menu();
        private Menu _chooseTitleMenu = new Menu();



        public override void Display()
        {
            base.Display();

            InitializeMembersMenu();

            OutputHelper.WriteLine("Choose a member: ", ConsoleColor.Blue);
            _chooseMemberMenu.Display();

            Console.Clear();
            
            OutputHelper.WriteLine("Select a title to return: ", ConsoleColor.Blue);
            _chooseTitleMenu.Display();

            InputHelper.ReadKey("Press any key to return to Rental page...");

            this.Application.NavigateBack();

        }


        private void InitializeMembersMenu()
        {
            var members = GetAllMembers();

            for (int i = 0; i < members.Count; i++)
            {
                var member = members[i];    
                _chooseMemberMenu.Add(i + 1, members[i].ToString(), () => InitializeEntriesMenu(member));
            }
        }

        private void InitializeEntriesMenu(Member member)
        {
            var rentEntries = this._rentalEntryService.GetByUnreturnedMember(member.Id);

            for (int i = 0; i < rentEntries.Count; i++)
            {
                var rentEntry = rentEntries[i];
                _chooseTitleMenu.Add(i + 1, rentEntries[i].ToString(), () => ReturnTitle(rentEntry));
            }
        }

        private void ReturnTitle(RentalEntry entry)
        {
            // islateCheck

            if (this._rentalEntryService.IsEntryPastDue(entry))
            {
                OutputHelper.WriteLine("You are late with the returning of this title!", ConsoleColor.Red);

                // feeCalculation
                var fee = this._rentalEntryService.CalculateReturnalFee(entry);

                OutputHelper.WriteLine($"The fee for your late returnal is: {fee} Euro", ConsoleColor.Red);

                InputHelper.ReadKey("Press any key to continue...");
            }


            var result = this._rentalEntryService.Return(entry);

            OutputHelper.WriteLine("Title returned successfully", ConsoleColor.Green);

        }

        private List<Member> GetAllMembers()
        {
            return this._memberRepository.GetAll().ToList();
        }
    }
}
