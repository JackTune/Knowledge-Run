using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace Assets.Scripts
{
    class Pergunta
    {
        public string Materia { get; set; }
        public string Enunciado { get; set; }
        public string[] Alternativas { get; set; }
        public string AlternativaCorreta { get; set; }

        public Pergunta(string Materia, string Enunciado, string[] Alternativas, string alternativaCorreta)
        {
            this.Alternativas = new string[Alternativas.Length];
            this.Materia = Materia;
            this.Enunciado = Enunciado;
            this.Alternativas = Alternativas;
            this.AlternativaCorreta = alternativaCorreta;
        }

        public static Pergunta GetPerguntas(string materia)
        {
            Pergunta retorno;

            MySqlCommand selectPerguntas = ConectarBanco.Conexao.CreateCommand();
            MySqlCommand selectNumero = ConectarBanco.Conexao.CreateCommand();

            selectPerguntas.CommandText = "SELECT * FROM perguntas WHERE (materia = '" + materia + "')";
            selectNumero.CommandText = "SELECT COUNT(*) FROM perguntas WHERE (materia = '" + materia + "')";

            

            int Max = Convert.ToInt32(selectNumero.ExecuteScalar());
            MySqlDataReader reader = selectPerguntas.ExecuteReader();

            Random number = new Random();
            int numberRnd = number.Next(0, Max);

            int j = 0;
            while (reader.Read())
            {
                string[] alternativas = new string[4];

                string k = "";
                for (int i = 0; i < 4 ; i++)
                {
                    
                    k = (k == "") ? "A" : (k == "A") ? "b" : (k == "b") ? "c" : "d";
                    alternativas[i] = (string)reader[k];
                }
                retorno = new Pergunta((string)reader["materia"], (string)reader["pergunta"], alternativas, (string)reader["correta"]);
                
                if (j == numberRnd)
                {
                    reader.Close();
                    return retorno;
                }
                j++;
            }
            reader.Close();
            return null;
        }
    }
}
