using Library.Core.Abstractions.Repositories;
using Library.Core.Entities;
using Library.UI.Base;
using Library.UI.Helpers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.UI.Pages.Members
{
    internal class AddMemberPage : MenuPageBase
    {

        private const string PAGE_HEADER = "Add member page";
        internal AddMemberPage(Application app): base(PAGE_HEADER, app)
        {
            this._memberRepository = app.Services.GetService<IMemberRepository>();
        }

        private readonly IMemberRepository _memberRepository;

        public override void Display()
        {
            base.Display();

            AddNewMember();
        }

        private void AddNewMember()
        {
            var newMember  = new Member();


            newMember.FirstName = InputHelper.ReadString("Enter member's first name: ");
            newMember.LastName = InputHelper.ReadString("Enter member's last name: ");
            newMember.DateOfBirth = InputHelper.ReadDateTime($"Enter member's date of birth ({CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern}):");
            newMember.PersonalId = InputHelper.ReadString("Enter member's personal id: ");

            try
            {
                var result = this._memberRepository.Create(newMember);
            
                if (result is null)
                {
                    OutputHelper.WriteLine("Member not created");
                } else
                {
                    OutputHelper.WriteLine("Member created successfully");
                }
            }
            catch (Exception ex)
            {

                OutputHelper.WriteLine("Member not created");
            }
            finally
            {
                InputHelper.ReadKey("Press any key to return to Members page....");
            }

            this.Application.NavigateBack();
        
        
        }
    }
}
