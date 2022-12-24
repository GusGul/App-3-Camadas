using Database.Attributes;
using Database.Repositorios.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Database.Repositorios
{
    public class Repositorio<T> : IRepositorio<T>
    {
        private static readonly string connStr = "server=localhost;user=root;database=trescamadas;port=3306;password=179179;";

        private string NomeTabela()
        {
            var nome = (typeof(T).Name.ToLower() + "s");

            TableAttribute? tabelaAttr = (TableAttribute?)typeof(T).GetCustomAttribute(typeof(TableAttribute));
            if (tabelaAttr != null)
            {
                nome = tabelaAttr.Nome;
            }
            return nome;
        }

        public void Gravar(T obj)
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();

                List<string> colunasArray = new List<string>();
                List<string> valoresArray = new List<string>();
                foreach (var prop in typeof(T).GetProperties())
                {
                    if (prop.Name == "Id") continue;
                    colunasArray.Add(prop.Name);
                    valoresArray.Add($"'{prop.GetValue(obj)}'");
                    //valoresArray.Add($"{prop.Name}='{prop.GetValue(obj)}'");
                }
                var colunas = string.Join(", ", colunasArray.ToArray());
                var valores = string.Join(", ", valoresArray.ToArray());

                string query = $"INSERT INTO {this.NomeTabela()} ({colunas}) VALUES ('')";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            conn.Close();
            Console.WriteLine("Done.");
        }

        public static List<T> Busca()
        {
            var usuarios = new List<T>();

            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();

                string query = "SELECT * FROM usuarios";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                var dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    usuarios.Add(new Usuario
                    {
                        CPF = dataReader["cpf"].ToString(),
                        Nome = dataReader["nome"].ToString(),
                        Telefone = dataReader["telefone"].ToString(),
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            conn.Close();
            return usuarios;
        }
    }
}
