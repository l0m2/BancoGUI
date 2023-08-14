using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco
{
    class ObInscricao
    {
        private string nome;
        private string apelido;
        private string telefone;
        private string bi;
        private string email;
        private string celular;
        private string data_Nasc;
        private string bairro;

        public ObInscricao(string Nome, string Apelido, string Telefone, string BI, string Email, string Celular, string Data_Nasc, string Bairro)
        {
            this.nome = Nome;
            this.apelido = Apelido;
            this.telefone = Telefone;
            this.bi = BI;
            this.email = Email;
            this.celular = Celular;
            this.data_Nasc = Data_Nasc;
            this.bairro = Bairro;

        }
        public ObInscricao() { }

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }
        public string Apelido
        {
            get { return apelido; }
            set { apelido = value; }
        }

        public string Telefone
        {
            get { return telefone; }
            set { telefone = value; }
        }

        public string BI
        {
            get { return bi; }
            set { bi = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Celular
        {
            get { return celular; }
            set { celular = value; }
        }

        public string Data_Nac
        {
            get { return data_Nasc; }
            set { data_Nasc = value; }
        }

        public string Bairro
        {
            get { return bairro; }
            set { bairro = value; }
        }

    }
}