using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Attributes
{
    public class TableAttribute : Attribute
    {
        public string Nome { get; set; }
    }
}
