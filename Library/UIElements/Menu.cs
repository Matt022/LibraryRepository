
using Library.UI.Helpers;

namespace Library.UI
{
    internal class Menu
    {
        private List<Option> Options { get; set; }

        public Menu()
        {
            Options = new List<Option>();
        }

        public void Display()
        {
            foreach (var option in Options)
            {
                OutputHelper.WriteLine($"{option.Ordinal} - {option.Name}");
            }

            int choice = InputHelper.ReadInt("Choose an option: ", 1, Options.Count);

            Options[choice - 1].CallBack();
        }

        

        public Menu Add(int ordinal, string option, Action callback)
        {
            return Add(new Option(ordinal, option, callback));
        }

        public Menu Add(Option option)
        {
            Options.Add(option);
            return this;
        }

        public bool Contains(string option)
        {
            return Options.FirstOrDefault(op => op.Name == option) == null;
        }
    }
}
