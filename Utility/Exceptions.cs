using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingdomEngine
{
    public class NotEnoughGoldException : Exception
    {
        public NotEnoughGoldException()
        {
        }

        public NotEnoughGoldException(string message) : base(message)
        {
        }

        public NotEnoughGoldException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
