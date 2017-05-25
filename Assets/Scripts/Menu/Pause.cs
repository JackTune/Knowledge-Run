using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour {

    public GameObject telaEscura;
	public GameObject Configs, Configs2;
    public Button buttonResume, buttonQuit, buttonOptions, buttonBackMenu, saveBT;
	bool Pausado = true;
    public Text AudioTxt;
    public Slider barraVolume;
    public Toggle SteroTG;

    public Text GameplayTxt;
    public Text CharacterTxt;
    public Dropdown SkinsDP;

    public Text VideoTxt;
    public Toggle modeWindow;
    public Dropdown Resolucoes, Qualidades;

    // Use this for initialization
    void Start () {
        telaEscura.SetActive(false);
		Configs.SetActive (false);
		Configs2.SetActive (false);

	}
	
	// Update is called once per frame
	void Update ()
    {
		if (Input.GetKeyDown(KeyCode.Escape) & Pausado == true)
        {
            Stop();
        }
    }

	//Voids do Pause
    public void Stop()
    {
        //Botões do pause
		Configs2.SetActive(true);
		telaEscura.SetActive (true);
        Time.timeScale = 0;

    }
    public void ReturnGame()
    {
        //Despause
		telaEscura.SetActive(false);
		Configs2.SetActive (false);
        Time.timeScale = 1;
		Pausado = true;
    }
    public void Sair()
    {
        Application.Quit();
    }
    public void BackMenu()
    {
        SceneManager.LoadScene("Menu");
    }


	//Void Opções
    public void Options() {

		Pausado = false;
        //Butões do Pause
		Configs2.SetActive(false);

        //Opções
		Configs.SetActive(true);
    }
}
