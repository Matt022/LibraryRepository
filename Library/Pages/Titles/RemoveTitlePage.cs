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
    internal class RemoveTitlePage : PageBase
    {
        private const string PAGE_HEADER = "Remove Title Page";

        public readonly IBookRepository? _bookRepository;

        private readonly IDvdRepository? _dvdRepository;

        public RemoveTitlePage(Application app) : base(PAGE_HEADER, app)
        {
            this._bookRepository = this.Application.Services.GetService<IBookRepository>();
            this._dvdRepository = this.Application.Services.GetService<IDvdRepository>();
        }

        public override void Display()
        {
            base.Display();
            try
            {
                var titles = this.GetTitles();

                if (titles.Count == 0)
                {
                    NoTitleAvailable();
                }

                OutputHelper.WriteLine("Available titles: ");
                var titlesCount = DisplayTitles(titles);

                var input = InputHelper.ReadInt($"Select a title to delete: ", 1, titlesCount);

                var titleToRemove = titles[input - 1];

                Title result = titleToRemove is Book ? this._bookRepository.Delete(titleToRemove.Id) : this._dvdRepository.Delete(titleToRemove.Id);
                
                if (result is not null)
                {
                    OutputHelper.WriteLine("Title removed successfully!");
                }
            
            } catch (Exception ex)
            {
                OutputHelper.WriteLine("Title not removed");
            } finally
            {
                InputHelper.ReadKey("Press key to continue...");
                this.Application.NavigateBack();
            }
        }

        private void NoTitleAvailable()
        {
            InputHelper.ReadKey("No titles to remove. Press any key to return to titles...");
            this.Application.NavigateBack();
        }

        private int DisplayTitles(List<Title> titles)
        {
            var sb = new StringBuilder();

            for (int i = 0; i < titles.Count; i++)
            {
                sb.AppendLine($"{i + 1}. {titles[i].ToString()}");
            }

            OutputHelper.WriteLine(sb.ToString());
            return titles.Count;
        }

        private List<Title> GetTitles()
        {
            var result = new List<Title>();

            result.AddRange(this?._bookRepository.GetAll());
            result.AddRange(this._dvdRepository.GetAll());

            return result;  
        }
    }
}
