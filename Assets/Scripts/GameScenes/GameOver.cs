using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Assets.Scripts;

public class GameOver : MonoBehaviour
{
    public Text tempo;


	// Use this for initialization
	void Start ()
    {
        MyMethods.cenaAtual = 0;
        tempo.text += PlayerScript.Score.ToString() + "s";
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void VoltarParaMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
