using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTAD.Lab.G01.Domain;

namespace UTAD.Lab.G01.Domain
{
    public class Categoria
    {
        public string categoria { get;private set; }

        public Categoria()
        {
            categoria = "";
        }
        public Categoria(string cat)
        {
            categoria=cat;
        }

        public void EditarCategoria(string novo)
        {
            categoria = novo;
        }
    }
}
