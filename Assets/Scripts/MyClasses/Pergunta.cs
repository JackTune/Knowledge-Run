using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    class Pergunta
    {


             /*        
             AINDA NÃO IMPLEMENTADO
             AINDA NÃO IMPLEMENTADO
             AINDA NÃO IMPLEMENTADO
             AINDA NÃO IMPLEMENTADO               
             */
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
    }
}
