using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTAD.Lab.G01.Domain
{
    public class Categoria
    {
        public string categoria { get; set; }
        public bool fixa_criada { get;  set; }

        public Categoria()
        {
            categoria = "";
            fixa_criada = false;
        }
        public Categoria(string cat)
        {
            categoria=cat;
            fixa_criada = false;
        }

        public void EditarCategoria(string novo)
        {
            categoria = novo;
        }
    }
}
