using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Database
{
    public abstract class Base : IPessoa
    {
        public Base(string nome, string telefone, string cpf)
        {
            this.Nome = nome;
            this.Telefone = telefone;
            this.CPF = cpf;
        }

        public Base() { }

        public string Nome;
        public string Telefone;
        public string CPF;

        public void SetCPF(string cpf) { this.CPF = cpf; }
        public void SetNome(string nome) { this.Nome = nome; }
        public void SetTelefone(string telefone) { this.Telefone = telefone; }

        public virtual void Gravar()
        {
            string? connStr = null;
            MySqlConnection conn;
            connStr = "server=localhost;user=root;database=trescamadas;port=3306;password=179179;";
            conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
              
                //string sql = "INSERT INTO "+this.GetType().Name+"s (cpf, nome, telefone) VALUES ('${this.CPF}', '${this.Nome}', '${this.Telefone}')";
                string sql = "INSERT INTO usuarios (cpf, nome, telefone) VALUES ('"+this.CPF+"', '"+this.Nome+"', '"+this.Telefone+"')";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            conn.Close();
            Console.WriteLine("Done.");
        }
    }
}
