using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTAD.Lab.G01.Domain;


namespace UTAD.Lab.G01.Domain
{
    public delegate void Notificacao_simples();
    public delegate void NotificacaoUmaString(string nome_list);
    public delegate void NotificacaoDuasStrings(string nome, string desc);
    public delegate void NotificacaoTresStrings(string nome, string quant, string cat);
    public delegate void NotificacaoUmInt(int i);
}
