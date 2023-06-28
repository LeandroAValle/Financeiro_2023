using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Responsavel por retornar todas as notificações, botificações e mensagens para o font
namespace Entities.Notificacoes 
{
    public class Notifica
    {
        public Notifica() {

            notificacoes = new List<Notifica>();

        }

        [NotMapped]
        public string NomePropriedade { get; set; }
        [NotMapped]
        public string mensagem { get; set; }
        [NotMapped]
        public List<Notifica> notificacoes;

        //validações

        public bool ValidarPropriedadeString( string valor, string nomePropriedade)
        {
            //Se o campo foi digitado
            if (string.IsNullOrWhiteSpace(valor) || string.IsNullOrWhiteSpace(nomePropriedade)) {

                notificacoes.Add(new Notifica
                {
                    mensagem = "Campo Obrigatório",
                    NomePropriedade = nomePropriedade

                }); ;

                return false;
            }

            return true;
        }

        public bool ValidarPropriedadeInt(int valor, string nomePropriedade)
        {
            //Se o campo foi digitado
            if (valor < 1 || string.IsNullOrWhiteSpace(nomePropriedade))
            {

                notificacoes.Add(new Notifica
                { 
                    mensagem = "Campo Obrigatório",
                    NomePropriedade = nomePropriedade

                }); ;

                return false;
            }

            return true;
        }

    }
}
