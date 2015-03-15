using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employgroup.Plugins.Framework
{
    public class TransformerException : Exception
    {
        public TransformerException()
        {
        }

        public TransformerException(string message)
            : base(message)
        {
        }

        public TransformerException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
