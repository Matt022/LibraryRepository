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
    internal class AllMembersPage : MenuPageBase
    {
        private const string PAGE_HEADER = "All members page";
        internal AllMembersPage(Application app) : base(PAGE_HEADER, app)
        {
            this._memberRepository = app.Services.GetService<IMemberRepository>();
        }

        private readonly IMemberRepository _memberRepository;

        public override void Display()
        {
            base.Display();

            DisplayAllMembers();    
        }

        private void DisplayAllMembers()
        {
            var members = GetMembers();
            var sb = new StringBuilder();

            foreach (var member in members)
            {
                sb.AppendLine(member.ToString());
            }

            OutputHelper.WriteLine(sb.ToString());

            InputHelper.ReadKey("Press any key to return to Members page...");
            this.Application.NavigateBack();
        }

        private List<Member> GetMembers()
        {
            return this._memberRepository.GetAll().ToList();
        }
    }
}
