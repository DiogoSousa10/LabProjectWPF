using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTAD.Lab.G01.Domain;

namespace UTAD.Lab.G01.Domain
{
    public class ClassItem
    {
        public string Name { get;set; }
        public string quantia { get; set; }
        public bool Estado { get; set; }
        public Categoria Categoria { get; set; }

        



        public ClassItem()
        {
            Name = "";
            quantia = "";
            Estado= false;
            Categoria = new Categoria();
          
        }

        public ClassItem(string name, string quant, string categoria)
        {
            Name = name;
            quantia= quant;
            Categoria = new Categoria(categoria);
            Estado= false;
        }

        public void ChangeState()
        {
            if(Estado == true)
            {
                Estado = false;
            }
            else
            {
                Estado = true;
            }
        }
        public void EditarItem(string name, string quant, string cat)
        {
            Name=name;
            quantia= quant;
            Categoria.EditarCategoria(cat);
        }

        
    }
}
