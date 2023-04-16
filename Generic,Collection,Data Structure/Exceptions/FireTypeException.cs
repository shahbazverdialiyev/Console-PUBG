using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic_Collection_Data_Structure.Exceptions;
internal class FireTypeException : Exception
{
    public FireTypeException() : base("Not Fire Type")
    {

    }
    public FireTypeException(string message) : base(message)
    {

    }
}

