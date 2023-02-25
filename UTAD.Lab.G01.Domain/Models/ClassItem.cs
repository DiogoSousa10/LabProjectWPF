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
        Random random = new Random();
        public int id { get;private set; }
        public string Name { get;private set; }
        public string quantia { get;private set; }
        public bool Estado { get;private set; }
        public Categoria Categoria { get;private set; }

        public ClassItem()
        {
            id= random.Next(1,100);
            Name = "";
            quantia = "";
            Estado= false;
            Categoria = new Categoria();
        }

        public ClassItem(string name, string quant, string categoria)
        {
            id = random.Next(1, 100);
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
