using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic_Collection_Data_Structure.Exceptions;
    internal class CapacityException:Exception
    {
        public CapacityException():base("Capacity is full")
        {

        }
    }
