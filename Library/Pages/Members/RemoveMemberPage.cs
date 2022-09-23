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

namespace Library.UI.Pages.Members
{
    internal class RemoveMemberPage : MenuPageBase
    {
        private const string PAGE_HEADER = "Remove member page";

        internal RemoveMemberPage(Application app) : base(PAGE_HEADER, app)
        {
            this._memberRepository = app.Services.GetService<IMemberRepository>();

            InitializeOptions();
        }

        private readonly IMemberRepository _memberRepository;

        public override void Display()
        {
            base.Display();

            OutputHelper.WriteLine("Choose a member to delete: ", ConsoleColor.Blue);
            this.Menu.Display();
        }

        private void DeleteMember(Member member)
        {
            try
            {
                var result = this._memberRepository.Delete(member.Id);

                if (result is null)
                    OutputHelper.WriteLine("Member not deleted.", ConsoleColor.Red);
                else OutputHelper.WriteLine("Member deleted successfully.", ConsoleColor.Green);
            }
            catch (Exception ex)
            {
                OutputHelper.WriteLine("Member deleted successfully.");
            }
            finally
            {
                InputHelper.ReadKey("Press any key to return to Members page...");
            }

            this.Application.NavigateBack();
        }

        private void InitializeOptions()
        {
            var members = GetMembers();

            for (int index = 0; index < members.Count; index++)
            {
                var member = members[index];
                this.Menu.Add(new Option(index + 1, member.ToString(), () => this.DeleteMember(member)));
            }

        }

        private List<Member> GetMembers()
        {
            return this._memberRepository.GetAll().ToList();
        }
    }
}