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

namespace Library.UI.Pages.Messages
{
    internal class MessagesPage : MenuPageBase
    {
        private const string PAGE_HEADER = "Messages page";

        private readonly IMessagingService _service;

        private readonly IMemberRepository _members;

        internal MessagesPage(Application app) : base(PAGE_HEADER, app)
        {
            this._service = app.Services.GetService<IMessagingService>();
            this._members = app.Services.GetService<IMemberRepository>();

        }

        private void InitializeMenu()
        {
            var members = GetAllMembers();

            for (int i = 0; i < members.Count; i++)
            {
                var member = members[i];
                Menu.Add(i + 1, $"{member.FirstName} {member.LastName}", () => ShowMessagesForMember(member) );
            }
        }

        private void ShowMessagesForMember(Member member)
        {

            Console.Clear();
            var messages = this._service.GetMessagesForUser(member.Id);

            if (messages.Count == 0)
            {
                OutputHelper.WriteLine("No messages to display...", ConsoleColor.Magenta);
                return;
            }

            var sb = new StringBuilder();
            foreach (var message in messages)
            {
                sb.AppendLine($"Sent: {message.SendData} - Subject: {message.MessageSubject} {Environment.NewLine} {Environment.NewLine} {message.MessageContext} {Environment.NewLine}");
            }

            OutputHelper.WriteLine(sb.ToString());  
        }

        private List<Member> GetAllMembers()
        {
            return _members.GetAll().ToList();
        }


        public override void Display()
        {
            base.Display();
            this.InitializeMenu();

            Menu.Display();

            InputHelper.ReadKey("Press any key to return to Main menu...");

            this.Application.NavigateBack();
        }
    }

}
