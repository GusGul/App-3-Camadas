using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public abstract class AEndereco
    {
        public AEndereco(string logradouro, int numero, string cidade, string estado)
        {
            this.Logradouro = logradouro;
            this.Numero = numero;
            this.Cidade = cidade;
            this.Estado = estado;
        }
        
        public AEndereco() { }

        public string Logradouro = default!;
        public int Numero = default!;
        public string Cidade = default!;
        public string Estado = default!;

        public void SetLogradouro(string logradouro) { this.Logradouro = logradouro; }
        public void SetNumero(int numero) { this.Numero = numero; }
        public void SetCidade(string cidade) { this.Cidade = cidade; }
        public void SetEstado(string estado) { this.Estado = estado; }

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
                string sql = "INSERT INTO enderecos (logradouro, numero, cidade, estado) VALUES ('" + this.Logradouro + "', '" + this.Numero + "', '" + this.Cidade + "', '" + this.Estado + "')";
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
