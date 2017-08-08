using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BotUbik.Dialog
{
    public class Dialog
    {
        #region "Mensagens do Bot"
        public string Saudacao = "Olá eu sou o BotDev, em que posso ajuda-lo?";
        public string perguntaAjuda = "Qual tipo de solicitação que você deseja?";
        public string perguntaProblema = "Qual tipo de problema você está tendo no momento?";
        public string dialogDev = "Este tipo de solicitação deverá ser tratado pelo setor de Desenvolvimento (TI).";
        public string msgAutomatica = "Desculpe, não entendi";
        public string problemaSuporte = "Este tipo de solicitação deverá ser tratado pelo setor de Suporte (TI).";
        public string erro = "Desculpe, não entendi";
        public string finalizacao = "Agradeçemos o seu contato. Caso precise de mim, é só me chamar";
        public string problemaFinanceiro = "Este tipo de solicitação deverá ser tratado pelo setor Financeiro.";
        public string problemaComercial = "Este tipo de solicitação deverá ser tratado pelo setor Comercial.";
        #endregion

        //Método verifica a mensagem do usuário e faz o retorno
        public string MsgUsuario(string mensagem)
        {
            string[] msg = new string[] { "OI", "OLÁ BOM DIA", "OLA", "BOA TARDE", "OLA", "HEY", "BOM DIA", "BOA NOITE" };
            int index = Array.IndexOf(msg, mensagem.Trim().ToUpper());

            if (index >= 0)
            {
                return (msg[index]);
            }
            else
            {
                return "Não foi possível enteder sua necessidade";
            }

            msg[index] = mensagem;
            return mensagem;
        }
        

        #region "antigo"
        //    //if (mensagem.ToUpper() == "OI" 
        //    //    || mensagem.ToUpper() == "OLÁ BOM DIA" 
        //    //    || mensagem.ToUpper() == "OLÁ" 
        //    //    || mensagem.ToUpper() == "OLA"
        //    //    || mensagem.ToUpper() == "HEY"
        //    //    || mensagem.ToUpper() == "BOM DIA"
        //    //    || mensagem.ToUpper() == "BOA TARDE"
        //    //    || mensagem.ToUpper() == "BOA NOITE"
        //    //    || mensagem.ToUpper() == "EAE"
        //    //    || mensagem.ToUpper() == "OEEE"
        //    //    || mensagem.ToUpper() == "IAI")
        //    //{
        //    //    return mensagem;
        //    //}
        //}
        #endregion
    }
}