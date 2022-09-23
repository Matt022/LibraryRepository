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

namespace Library.UI.Pages.Titles
{

    internal class AllTitlesPage : PageBase
    {
        private const string PAGE_HEADER = "All Titles";

        private IBookRepository? _bookRepository;

        private IDvdRepository? _dvdRepository;
        public AllTitlesPage( Application app) : base(PAGE_HEADER, app)
        {
            this._bookRepository = app.Services.GetService<IBookRepository>();
            this._dvdRepository = app.Services.GetService<IDvdRepository>();

        }

        public override void Display()
        {
            base.Display();

            DisplayAllTitles();


            InputHelper.ReadKey($"{Environment.NewLine}Press any key to return to Titles menu...");
            this.Application.NavigateBack();

        }

        private void DisplayAllTitles()
        {
            var titles = GetAllTitles();

            if (titles.Count == 0)
            {
                OutputHelper.WriteLine("No titles available");
            }

            var sb = new StringBuilder();

            foreach (var title in titles)
            {
                sb.AppendLine(title.ToString());
            }

            OutputHelper.WriteLine(sb.ToString());
        }

        private List<Title> GetAllTitles()
        {
            var result = new List<Title>();

            result.AddRange(this._bookRepository.GetAll());
            result.AddRange(this._dvdRepository.GetAll());

            return result;
        }
    }
}
