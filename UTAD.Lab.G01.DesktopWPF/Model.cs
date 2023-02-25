using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace UTAD.Lab.G01.Domain
{
    public class Model
    {
        public List<Categoria> Categorias { get; private set; }
        public List<Lista> Listas { get; private set; }

        public event NotificacaoUmaString RemovidoComSucesso;
        public event NotificacaoUmaString InsercaoComSucesso;
        public event NotificacaoDuasStrings ListaCriadaComSucesso;
        public event NotificacaoTresStrings ItemCriadoComSucesso;
        public event NotificacaoUmaString ListaEnviada;
        public event Notificacao_simples ListaCarregada;
        public event Notificacao_simples ListaSalvada;
        public event Notificacao_simples ListaApagada;
        public event NotificacaoDuasStrings ListaEditada;
        public event NotificacaoDuasStrings CategoriaEditada;
        public event NotificacaoUmaString CatEnviada;
        public event NotificacaoUmInt ListaSelecionada;

        public Model()
        {
            Categorias = new List<Categoria>();
            Listas = new List<Lista>();
            Categorias.Add(new Categoria("Padaria"));
            Categorias.Add(new Categoria("Bazar"));
            Categorias.Add(new Categoria("Mercearia"));
            Categorias.Add(new Categoria("Frios e Lacticineos"));
            Categorias.Add(new Categoria("Limpeza"));
            Categorias.Add(new Categoria("Ferragens"));
            Categorias.Add(new Categoria("Bricolage"));
            Categorias.Add(new Categoria("Automoveis"));
            foreach(Categoria aux in Categorias)
            {
                aux.fixa_criada = true;
            }
        }


        public void Categoria_Enviada(string nome)
        {
            if (String.IsNullOrEmpty(nome) == false)
            {
                if (CatEnviada != null)
                {
                    CatEnviada(nome);
                }
            }
            else
            {
                throw new ExcecaoInvalida("Categoria Não Selecionada");
            }
        }

        public void AdicionarCategoria(string _cat)
        {
            if (_cat != null)
            {
                Categorias.Add(new Categoria(_cat));

                if (InsercaoComSucesso != null)
                    InsercaoComSucesso(_cat);
            }
            else
            {
                throw new ExcecaoInvalida("Textbox não preenchida");
            }


        }

        public void RemoveCat(string _cat)
        {
            int index = 0;
            foreach (Categoria aux in Categorias)
            {
                if (aux.categoria != _cat)
                {
                    index++;
                }
            }
            Categorias.RemoveAt(index);

            if (RemovidoComSucesso != null)
                RemovidoComSucesso(_cat);
        }

        public void CreateList(string _nome, string _desc)
        {
            bool rep = false, rep2 = true;
            int ver = 1;
            if (_nome != null)
            {
                foreach (Lista l in Listas)
                {
                    if (_nome == l.Nome)
                    {
                        rep = true;
                    }
                }
                if (rep == true)
                {
                    while (rep2 != false)
                    {
                        foreach (Lista l in Listas)
                        {
                            if (_nome + ver.ToString() == l.Nome)
                            {
                                rep2 = true;
                            }
                            else
                            {
                                rep2 = false;
                            }
                        }
                        if (rep2 == true)
                        {
                            ver++;
                        }
                    }
                    _nome = _nome + ver.ToString();
                    Listas.Add(new Lista(_nome, _desc));

                }
                else
                {
                    Listas.Add(new Lista(_nome, _desc));
                }
                rep = false;
                if (ListaCriadaComSucesso != null)
                {
                    ListaCriadaComSucesso(_nome, _desc);
                }
            }
            else
            {
                throw new ExcecaoInvalida("Nome não preenchido");
            }
        }

        public void AdicionarItem(string nome_list, string nome, string quant, string cat)
        {
            if (String.IsNullOrEmpty(nome_list) == false && String.IsNullOrEmpty(nome) == false && String.IsNullOrEmpty(quant) == false && String.IsNullOrEmpty(cat) == false)
            {

                Listas[GetIndexList(nome_list)].Adicionar_IteM(nome, quant, cat);

                if (ItemCriadoComSucesso != null)
                    ItemCriadoComSucesso(nome, quant, cat);
            }
            else
            {
                throw new ExcecaoInvalida("Campos não preenchidos");
            }

        }

        public int GetIndexList(string nome_list)
        {
            int index = 0;
            foreach (Lista aux in Listas)
            {
                if (aux.Nome != nome_list)
                {
                    index++;
                }
            }

            return index;

        }

        public void ListaEnviada2(string a)
        {
            if (String.IsNullOrEmpty(a) == false)
            {
                if (ListaEnviada != null)
                    ListaEnviada(a);
            }
            else
            {
                throw new ExcecaoInvalida("Lista Não selecionada");
            }

        }
        public void Save_Listas()
        {
            XDocument doc = new XDocument();

            // não é necessário adicionar a declaração XML

            doc.Add(new XElement("ListasCompras")); // adiciona ao documento o nó raiz
            doc.Element("ListasCompras").Add(new XElement("Categorias",
                                            new XElement("Criada"),
                                            new XElement("Fixa"))); // adiciona o nó para guardar as Categorias
            doc.Element("ListasCompras").Add(new XElement("Listas")); // adiciona o nó para guardar as listas de compras


            XElement cats_c = doc.Root.Element("Categorias").Element("Criada");
            XElement cats_f = doc.Root.Element("Categorias").Element("Fixa");

            foreach (Categoria aux in Categorias)
            {
                XElement no = new XElement("Categoria");
                no.Add(new XAttribute("Nome", aux.categoria));

                if (aux.fixa_criada == false)
                {
                    cats_c.Add(no);
                }
                else
                {
                    cats_f.Add(no);
                }

            }

            XElement lists = doc.Root.Element("Listas");

            foreach (Lista aux in Listas)
            {
                XElement no = new XElement("Lista",
                                          new XElement("NaoComprados"),
                                          new XElement("Comprados"));
                no.Add(new XAttribute("Nome", aux.Nome));

                foreach (ClassItem p in aux.lista)
                {
                    XElement tmpProd = new XElement("Item");
                    tmpProd.Add(new XAttribute("Nome", p.Name));
                    tmpProd.Add(new XAttribute("Quantidade", p.quantia));
                    tmpProd.Add(new XAttribute("Categoria", p.Categoria.categoria));

                    if (p.Estado == true)
                    {
                        no.Element("Comprados").Add(tmpProd);
                    }
                    else
                    {
                        no.Element("NaoComprados").Add(tmpProd);
                    }
                }
                lists.Add(no);
            }
            doc.Save("Listas_Compras.xml");

            if (ListaSalvada != null)
            {
                ListaSalvada();
            }
        }
        public void Load_Listas()
        {
            bool rep = false, rep2 = true, rep_cat = false;
            int ver = 2;
            XDocument doc = XDocument.Load("Listas_Compras.xml");

            var cats_c = from al in doc.Root.Elements("Categorias").Elements("Criada").Descendants("Categoria") select al;
            var cats_f = from al in doc.Root.Elements("Categorias").Elements("Criada").Descendants("Categoria") select al;
            foreach (var aux in cats_c)
            {

                Categoria c = new Categoria();
                c.categoria = aux.Attribute("Nome").Value;
                c.fixa_criada = false;
                foreach (Categoria aux1 in Categorias)
                {
                    if (aux1.categoria != c.categoria)
                    {
                        rep_cat = true;
                    }
                }
                if (rep_cat == true)
                {
                    Categorias.Add(c);
                }
                rep_cat = false;

                Categorias.Add(c);
            }
            foreach (var aux in cats_f)
            {

                Categoria c = new Categoria();
                c.categoria = aux.Attribute("Nome").Value;
                c.fixa_criada = true;
                foreach (Categoria aux1 in Categorias)
                {
                    if (aux1.categoria != c.categoria)
                    {
                        rep_cat = true;
                    }
                }
                if (rep_cat == true)
                {
                    Categorias.Add(c);
                }
                rep_cat = false;
            }

            var listas = from lst in doc.Root.Elements("Listas").Descendants("Lista") select lst;

            foreach (var aux in listas)
            {
                Lista nova = new Lista() { Nome = aux.Attribute("Nome").Value };

                var produtos_nao = from al in aux.Element("NaoComprados").Descendants("Item") select al;

                foreach (var tmp in produtos_nao)
                {
                    ClassItem p = new ClassItem();
                    p.Name = tmp.Attribute("Nome").Value;
                    p.quantia = tmp.Attribute("Quantidade").Value;
                    p.Categoria.categoria = tmp.Attribute("Categoria").Value;
                    p.Estado = false;

                    nova.lista.Add(p);
                }
                var produts = from al in aux.Element("Comprados").Descendants("Item") select al;
                foreach (var tmp in produts)
                {
                    ClassItem p = new ClassItem();
                    p.Name = tmp.Attribute("Nome").Value;
                    p.quantia = tmp.Attribute("Quantidade").Value;
                    p.Categoria.categoria = tmp.Attribute("Categoria").Value;
                    p.Estado = true;

                    nova.lista.Add(p);
                }
                Listas.Add(nova);

                if (ListaCarregada != null)
                {
                    ListaCarregada();
                }
            }
        }

        public void Apagar_Lista(string Nome)
        {
            if (String.IsNullOrEmpty(Nome) == false)
            {
                int i = GetIndexList(Nome);

                Listas.RemoveAt(i);
                if (ListaApagada != null)
                {
                    ListaApagada();
                }
            }
            else
            {
                throw new ExcecaoInvalida("Lista Não Selecionada");
            }
        }
        public void Editar_Lista(string aux, string nome, string desc)
        {
            if (aux != null && nome != null && desc != null)
            {
                int i = GetIndexList(aux);

                Listas[i].Editar_Lista(nome, desc);

                if (ListaEditada != null)
                {
                    ListaEditada(aux,nome);
                }
            }
            else
            {
                throw new ExcecaoInvalida("Lista Não Selecionada");
            }
        }
        public void Editar_Categoria(string aux, string nome)
        {
            if (String.IsNullOrEmpty(aux) == false ) {
                int index = 0;
                foreach (Categoria aux1 in Categorias)
                {
                    if (aux1.categoria != aux)
                    {
                        index++;
                    }
                }

                Categorias[index].EditarCategoria(nome);

                if (CategoriaEditada != null)
                {
                    CategoriaEditada(aux,nome);
                }
            }
            else
            {
                throw new ExcecaoInvalida("Categoria não Selecionada");
            }
        }
        public void Lista_Selecionada (string nome)
        {
            int i = GetIndexList(nome);

            if(ListaSelecionada != null)
            {
                ListaSelecionada(i);
            }
        }
    }
}
