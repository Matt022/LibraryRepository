using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.UI.Base;
using Microsoft.Extensions.Configuration;
using Library.UI.Helpers;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Library.Core;
using Library.Infrastructure;
using Library.UI.Pages;
using Library.UI.Pages.Members;
using Library.UI.Pages.Rentals;
using Library.UI.Pages.Rentals.Queue;
using Library.UI.Pages.Titles;
using Library.UI.Pages.Messages;

namespace Library.UI
{
    public class Application
    {
        public Application(string title)
        {
            this.Title = title;
            Pages = new Dictionary<Type, PageBase>();
            History = new Stack<PageBase>();

            BuildConfigurations();

            BuildServices();

            BuildPages();
        }

        // name of the page
        protected string Title { get; set; }

        private Dictionary<Type, PageBase> Pages { get; set; }
    
        private Stack<PageBase> History { get; set; }

        internal PageBase CurrentPage => History.Any() ? History.Peek() : null;

        internal IConfiguration Configuration { get; set; }
        internal IServiceProvider Services { get; set; }

        // navigation to home
        internal void NavigateHome()
        {
            while(History.Count > 1)
            {
                History.Pop();
            }

            Console.Clear();
            CurrentPage?.Display();
        }

        internal void AddPage(PageBase page)
        {
            Type pageType = page.GetType();

            if (Pages.ContainsKey(pageType))
            {
                Pages[pageType] = page;
            } else
            {
                Pages.Add(pageType, page);
            }
        }


        internal T? NavigateTo<T>() where T: PageBase
        {
            if (CurrentPage != null && CurrentPage.GetType() == typeof(T))
            {
                return (T)CurrentPage;
            }
            PageBase? nextPage;

            if (!Pages.TryGetValue(typeof(T), out nextPage))
            {
                throw new Exception();
            }

            History.Push(nextPage);
            Console.Clear();
            CurrentPage?.Display();

            return CurrentPage as T;
        }

        internal PageBase NavigateBack()
        {
            History.Pop();

            Console.Clear();
            CurrentPage.Display();
            return CurrentPage;
        }

        public int Run()
        {
            try
            {
                Console.Title = Title;
                SetPage<MainPage>();

                CurrentPage?.Display();
                return 0;
            } catch(Exception ex)
            {
                OutputHelper.WriteLine( ex.Message );
                return -1;
            }
        }

        internal T SetPage<T>() where T : PageBase
        {
            Type pageType = typeof(T);

            if (CurrentPage != null && CurrentPage.GetType() == pageType)
            {
                return CurrentPage as T;
            }

            // leave the current page

            // select the new page
            PageBase nextPage;

            if (!Pages.TryGetValue(pageType, out nextPage))
            {
                throw new KeyNotFoundException($"The given page {pageType.Name} was not present in the program");
            }

            // enter the new page
            History.Push(nextPage);

            return CurrentPage as T;
        }


    
        private void BuildConfigurations()
        {
            this.Configuration = new ConfigurationBuilder()
                .AddJsonFile("appSettings.json")
                .AddEnvironmentVariables()
                .Build();

        }

        private void BuildServices()
        {
            var serviceProvider = new ServiceCollection();

            serviceProvider.AddSingleton(this.Configuration);
            serviceProvider.RegisterInfrastructureServices(this.Configuration);
            serviceProvider.RegisterCoreServices();
            this.Services = serviceProvider.BuildServiceProvider();
        }


        private void BuildPages()
        {
            this.AddPage(new MainPage(this));


            //Titles
            this.AddPage(new TitlesPage(this));
            this.AddPage(new AddTitlePage(this));
            this.AddPage(new RemoveTitlePage(this));
            this.AddPage(new AllTitlesPage(this));

            // Members
            this.AddPage(new MembersPage(this));
            this.AddPage(new AllMembersPage(this));
            this.AddPage(new AddMemberPage(this));
            this.AddPage(new RemoveMemberPage(this));

            // Rentals
            this.AddPage(new RentalsPage(this));
            this.AddPage(new AllRentalsPage(this));
            this.AddPage(new RentATitlePage(this));
            this.AddPage(new ProlongRentalPage(this));

            this.AddPage(new ReturnTitlePage(this));
            this.AddPage(new PastDueRentalsPage(this));
            this.AddPage(new QueuePage(this));

            // Messages
            this.AddPage(new MessagesPage(this));

        }

        public void Exit()
        {
            Environment.Exit(0);
        }
    }
}
