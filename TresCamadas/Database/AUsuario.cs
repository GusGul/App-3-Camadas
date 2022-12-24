using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Database
{
    public abstract class AUsuario
    {
        public AUsuario(string nome, string telefone, string cpf)
        {
            this.Nome = nome;
            this.Telefone = telefone;
            this.CPF = cpf;
        }

        public AUsuario() { }

        public string Nome = default!;
        public string Telefone = default!;
        public string CPF = default!;

        public void SetCPF(string cpf) { this.CPF = cpf; }
        public void SetNome(string nome) { this.Nome = nome; }
        public void SetTelefone(string telefone) { this.Telefone = telefone; }
        /*
        public virtual void Gravar()
        {
            
        }

        public virtual List<AUsuario> Busca()
        {
            break;
        }*/
    }
}
