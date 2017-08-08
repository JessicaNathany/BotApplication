using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Bot.Connector;
using BotUbik.Dialog;
using BotUbik.Atendimento;

namespace BotDev
{
    [BotAuthentication]
    public class MessagesController : ApiController
    {
        /// <summary>
        /// POST: api/Messages
        /// Receive a message from a user and reply to it
        /// </summary>
        public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
        {
            if (activity.Type == ActivityTypes.Message)
            {
                //retorna nossa mensagem para o usuário
                ConnectorClient connector = new ConnectorClient(new Uri(activity.ServiceUrl));
                int length = (activity.Text ?? string.Empty).Length;

                //return our reply to the user
                Activity reply = activity.CreateReply();
                Dialog dialog = new Dialog();

                //verifica mensagem do usuário
                dialog.MsgUsuario(activity.Text);
                
                //retorna mensagem de saudação para o usuário
                //TODO: JN CORRIGIR PROBLEMA DE RETORNO DESTE MÉTODO, MESMO MSG ERRADA, SAUDAÇÃO VEM CORRETA!
                reply = activity.CreateReply(dialog.Saudacao);
                  
                if (activity.Text.ToUpper().Contains("PROBLEMA"))
                {
                    reply = activity.CreateReply
                        (dialog.perguntaProblema + "\n\n" + Atendimento.Comercial +
                                                   "\n\n" + Atendimento.Financeiro +
                                                   "\n\n" + Atendimento.Suporte +
                                                   "\n\n" + Atendimento.Desenvolvimento + "\n\n");
                }

                if (activity.Text.ToUpper().Contains("VAGAS") || activity.Text.ToUpper().Contains("VAGA") || activity.Text.ToUpper().Contains("ORÇAMENTO"))
                {
                    reply = activity.CreateReply(dialog.problemaComercial + "envie um e - mail para: cobranca@ubik.com.br " + "\n\n" + "Telefone: 11 - 3179 - 1100(PABX)");
                }

                if (activity.Text.ToUpper().Contains("SUPORTE") 
                                        || activity.Text.ToUpper().Contains("EMAIL") 
                                        || activity.Text.ToUpper().Contains("E-MAIL")
                                        || activity.Text.ToUpper().Contains("SERVIDOR")
                                        || activity.Text.ToUpper().Contains("PROBLEMAS COM LENTIDÃO")
                                        || activity.Text.ToUpper().Contains("SEM ACESSO"))
                {
                    reply = activity.CreateReply(dialog.problemaComercial + "envie um e-mail para: comercial@ubik.com.br  " + "\n\n" + "Telefone: 11 - 3179- 1100(PABX)");
                }

                if (activity.Text.ToUpper().Contains("DESENVOLVIMENTO")
                                   || activity.Text.ToUpper().Contains("PROJETO")
                                   || activity.Text.ToUpper().Contains("LOJA VIRUTAL")
                                   || activity.Text.ToUpper().Contains("CONSULTORIA")
                                   || activity.Text.ToUpper().Contains("INTEGRAÇÃO DE SISTEMAS")
                                   || activity.Text.ToUpper().Contains("APLICAÇÃO MOBILE")
                                   || activity.Text.ToUpper().Contains("E-COMMERCE"))
                {
                    reply = activity.CreateReply(dialog.dialogDev + "envie um e - mail para: dev@ubik.com.br  " + "\n\n" + "Telefone: 11 - 3179 - 1100(PABX)");
                }

                await connector.Conversations.ReplyToActivityAsync(reply);
            }
            else
            {
                HandleSystemMessage(activity);
            }
            var response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }

        //Método recebe e envia mensagem para o usário
        private Activity HandleSystemMessage(Activity message)
        {
            if (message.Text == "oi")
            {
                Activity reply = message.CreateReply();
                reply.Type = "Oi";
                return reply;
            }
            else if (message.Type == "conversationUpdate")
            {
                return message.CreateReply("Olá eu sou o BotDev, em que posso ajuda-lo?");
            }

            else if (message.Type == "BotRemovedFromConversation")
            {

            }
            else if (message.Type == "UserUpdateToConversation")
            {
                return message.CreateReply("Tem alguma dúvida?");
            }
            else if (message.Type == "UserRemovedFromConversation")
            {

            }
            else if (message.Type == "EndOfConversation")
            {

            }

            else if (message.Type == "BotAddedToConversation")
            {
               return message.CreateReply("Olá Dev. Eu sou o BotDev e vim para ajuda-lo, qual a sua dúvida?");
            }

            return null;
        }
    }
}