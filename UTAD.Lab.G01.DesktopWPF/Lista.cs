using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTAD.Lab.G01.DesktopWPF;
using UTAD.Lab.G01.Domain;

namespace UTAD.Lab.G01.Domain
{
    public class Lista
    {
        public string Nome { get; set; }
        public string Des { get; set; }
        public List<ClassItem> lista { get; set; }


        public Lista()
        {
            Nome = "";
            Des = "";
            lista = new List<ClassItem>();
        }
        public Lista(string name, string des)
        {
            Nome = name;    
            Des = des;
            lista=new List<ClassItem>();
        }

        public void Adicionar_IteM(string name, string quant, string categoria)
        {
            ClassItem ItemAdd = new ClassItem(name, quant, categoria);
            lista.Add(ItemAdd);

        }
        public int Search_Item(string nome)
        {
            int index = 0;
            foreach (ClassItem aux in lista)
            {
                if (nome != aux.Name)
                {
                    index++;
                }
            }
            return index;
        }
        public void Remover_Item(string nome)
        {
            lista.RemoveAt(Search_Item(nome));
        }

        public void Editar_Item(string nome, string name , string quant, string categoria)
        {
            lista[Search_Item(nome)].EditarItem(name, quant, categoria);
        }

        public void Editar_Lista(string name , string desc)
        {
            Nome = name;
            Des = desc;
        }

        

    }
}
