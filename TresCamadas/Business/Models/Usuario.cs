using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database;
using Database.Attributes;
using MySql.Data.MySqlClient;

namespace Business.Models
{
    [Table(Nome = "fornecedores")]
    public class Usuario
    {
        public Usuario(string nome, string telefone, string cpf)
        {
            Nome = nome;
            Telefone = telefone;
            CPF = cpf;
        }

        public Usuario() { }

        public string Nome = default!;
        public string Telefone = default!;
        public string CPF = default!;

        public void SetCPF(string cpf) { this.CPF = cpf; }
        public void SetNome(string nome) { this.Nome = nome; }
        public void SetTelefone(string telefone) { this.Telefone = telefone; }

    }
}
