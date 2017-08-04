using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading;
using Assets.Scripts;

public class Responder : MonoBehaviour
{
    Pergunta perguntaP;
    [Header("Game Scenes")]
    public string[] Scenes;
    [Space(20)]
    [Header("Texts")]
	public Text pergunta;
    [Space(20)]
    public Text[] Respostas;
    [Space(20)]

    [Header("Strings")]
    public string[] alternativas;
    public string questao;
    public string correta;

    [Header("Botões")]
    [Space(5)]

    public Button[] botoes;

    void Start ()
    {
        string materia = MyMethods.LastScene;

        perguntaP = Pergunta.GetPerguntas(materia);
        MyMethods.ShuffleArray(perguntaP.Alternativas);

        pergunta.text = perguntaP.Enunciado;


        for (int i = 0; i < perguntaP.Alternativas.Length; i++)
        {
            Respostas[i].text = perguntaP.Alternativas[i];
        }
    }

    public void ChecarBotao(Button buttons)
    {
        if (buttons.GetComponentInChildren<Text>().text != perguntaP.AlternativaCorreta)
        {
            DesabilitarButoes(botoes);
            StartCoroutine(DelayDeErro(5));
        }
        else
        {
            DesabilitarButoes(botoes);
            MyMethods.ChangeScenes(Scenes);
        }
    }
    
    void DesabilitarButoes(Button[] botoes)
    {
        for (int i = 0; i < botoes.Length; i++)
        {
            botoes[i].enabled = false;
        }
    }

    IEnumerator DelayDeErro(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        MyMethods.ChangeScenes(Scenes);
    }
}
