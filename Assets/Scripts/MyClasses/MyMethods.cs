using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    static class MyMethods
    {

        public static string LastScene { get; set; }
        public static Pergunta[] perguntas;
        static int numeroCenas = 5;
        public static int cenaAtual = 0;
        public static Usuario User { get; set; }

        
        public static Pergunta[] GetPerguntas()
        {
            perguntas = new Pergunta[1];
            switch (LastScene)
            {
                case "MathBG": 
                    string[] alternativas = { "4", "22", "0", "5" };
                    perguntas[0] = new Pergunta("Matemática", "Quanto é 2 + 2", alternativas, "4");
                    break;
                case "PortBG": string[] alternativasPort = { "Não","Sim","Talvez","Nda"};
                    perguntas[0] = new Pergunta("Português", "Sim é não?", alternativasPort, "Não");
                    break;
                case "BioBG": string[] alternativasBio = { "Sim", "Não", "Talvez", "Nda" };
                    perguntas[0] = new Pergunta("Biologia", "Vírus são seres vivos?", alternativasBio, "Não");
                    break;
            }
            return perguntas;
        }

        public static void ChangeScenes(string[] Scenes)
        {
            //muda a cena aleatoriamente de acordo com o array de nomes
            System.Random index = new System.Random();
            int i = index.Next(0, (Scenes.Length));

            while (Scenes[i] == LastScene || SceneManager.GetActiveScene().name == Scenes[i])
            {
                i = index.Next(0, (Scenes.Length));          
            }
            if (true)
            {

            }
            if (cenaAtual < numeroCenas)
            {
                SceneManager.LoadScene(Scenes[i]);
                LastScene = Scenes[i];
                cenaAtual++;
            }
            else
            {
                SceneManager.LoadScene("GameOver");
            }
        }


        public static void ShuffleArray(string[] elements)
        {
            //Randomiza as posições de um array de string
            for(int i = 0; i < elements.Length; i++)
            {
                string tmp = elements[i];
                int rnd = UnityEngine.Random.Range(i, elements.Length);
                elements[i] = elements[rnd];
                elements[rnd] = tmp;
            }
        }
        public static void ShuffleArray(Text[] elements)
        {
            //Randomiza as posições de um array de Textos
            for (int i = 0; i < elements.Length; i++)
            {
                string tmp = elements[i].text;
                int rnd = UnityEngine.Random.Range(0, elements.Length);
                elements[i] = elements[rnd];
                elements[rnd].text = tmp;
            }
        }
    }
}
