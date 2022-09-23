namespace Library.UI.Base
{
    internal abstract class PageBase
    {
        public PageBase(string title, Application application)
        {
            this.Title = title;
            this.Application = application;
        }

        public string Title { get; set; }

        public Application Application { get; set; }
        public virtual void Display()
        {
            Console.WriteLine(Title);
        }
    }
}
