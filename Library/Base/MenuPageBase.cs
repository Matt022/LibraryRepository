

namespace Library.UI.Base
{

    internal abstract class MenuPageBase : PageBase
    {
        public MenuPageBase(string title, Application app) : base(title, app)
        {
            this.Menu = new Menu();
        }

        protected Menu Menu { get; set; }

        public override void Display()
        {
            Console.Clear();
            base.Display();
        }
    }

}
