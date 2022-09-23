

namespace Library.UI
{
    internal class Option
    {
        public string Name { get; set; }

        public Action CallBack { get; private set; }

        public int Ordinal { get; set; }
        public Option(int ordinal, string name, Action callback)
        {
            Ordinal = ordinal;
            Name = name;
            CallBack = callback;
        }
    }
}
