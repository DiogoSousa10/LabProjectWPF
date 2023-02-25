using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTAD.Lab.G01.Domain
{
    public class Lista
    {
        public string Nome { get;private set; }
        public string Des { get;private set; }
        public List<ClassItem> lista { get;private set; }

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
            lista.Add(new ClassItem(name, quant, categoria));
        }
        public void Remover_Item(int id)
        {
            var resultlist = lista.ToList();

            resultlist.RemoveAt(id);

        }

        public void Editar_Item(int id, string name , string quant, string categoria)
        {
            ClassItem produto = lista.FirstOrDefault(a => a.id == id);

            if (produto != null)
            {
                produto.EditarItem(name, quant, categoria);
            }
        }

        public void Editar_Lista(string name , string desc)
        {
            Nome = name;
            Des = desc;
        }
    }
}
