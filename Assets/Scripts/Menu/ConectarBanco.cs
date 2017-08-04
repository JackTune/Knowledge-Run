using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace Assets.Scripts
{
    static class ConectarBanco
    {
        static string source;
        public static MySqlConnection Conexao { get; private set; }


        public static void Conectar()
        {
            source = "Server=localhost;" +
                 "Database=knowledgerun;" +
                 "User ID=root;" +
                 "Pooling=false;" +
                 "Password=;";

            Conectar(source);
        }

        static void Conectar(string _source)
        {
            Conexao = new MySqlConnection(_source);
            Conexao.Open();
        }
    }
}
