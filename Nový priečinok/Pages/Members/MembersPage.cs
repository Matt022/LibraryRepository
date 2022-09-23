using Library.Core.Abstractions.Repositories;
using Library.UI.Base;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.UI.Pages.Members
{
    internal class MembersPage : MenuPageBase
    {
        private const string PAGE_HEADER = "Members page";

        public MembersPage(Application app) : base(PAGE_HEADER, app)
        {
            InitializeOptions();
        }


        private void InitializeOptions()
        {
            this.Menu.Add(1, "Show all members", () => this.Application.NavigateTo<AllMembersPage>());
            this.Menu.Add(2, "Add new member", () => this.Application.NavigateTo<AddMemberPage>());
            this.Menu.Add(3, "Remove member", () => this.Application.NavigateTo<RemoveMemberPage>());
            this.Menu.Add(4, "Back", () => this.Application.NavigateBack());

        }

        public override void Display()
        {
            base.Display();

            this.Menu.Display();
        }
    }
}
