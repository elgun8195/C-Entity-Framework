using System;
using System.Collections.Generic;
using System.Text;

namespace C_Sharp_Entity_Framework.Exceptions
{
    internal class NotFoundException:Exception
    {
        public NotFoundException(string message):base(message)
        {

        }
    }
}
