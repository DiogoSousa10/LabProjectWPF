using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace UTAD.Lab.G01.Domain
{
    public class ExcecaoInvalida : ApplicationException
    {
        public ExcecaoInvalida(string msg) : base(msg) { }

    }
}
