using Library.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Events
{
    public class TitleReturnedEventArgs : EventArgs
    {
        public TitleReturnedEventArgs(Title title)
        {
            Title = title;
        }

        public Title Title { get; set; }
    }
}
