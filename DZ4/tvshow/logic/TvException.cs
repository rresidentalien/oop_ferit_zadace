using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logic
{
    public class TvException : Exception
    {
        public string Title { get; private set; }

        public TvException(string message, string title) : base(message)
        {
            Title = title;
        }
    }
}