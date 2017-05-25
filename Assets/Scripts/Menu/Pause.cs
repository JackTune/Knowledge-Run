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

	public Text VideoTxt;
	public Toggle modeWindow;
	private int qualidadeGrafica, modeWindowActive, resolutionSaveIndex;
	public Dropdown Resolucoes, Qualidades;
	private bool screenFullActive;
	private Resolution[] resolutionsSupporteds;

	[Space(5)]

	public Text GameplayTxt;
	public Text CharacterTxt;
	public Dropdown SkinsDP;

	[Space(5)]

	public Text AudioTxt;
	private float Volume;
	public Slider barraVolume;
	public Toggle SteroTG;

    private void Awake()
    {
        resolutionsSupporteds = Screen.resolutions;
    }
    // Use this for initialization
    void Start () {
        telaEscura.SetActive(false);
		Configs.SetActive (false);
		Configs2.SetActive (false);

        Funcionalidades();
        ChecarResolucoes();
        AjustarQualidades();


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


	//Void Botões de Opções
    public void Options() {

		Pausado = false;
        //Butões do Pause
		Configs2.SetActive(false);

        //Opções
		Configs.SetActive(true);
 
    }

	//DENTRO DE OPÇÕES

	//Voids de checagem

	private void ChecarResolucoes()
	{
		resolutionsSupporteds = Screen.resolutions;
		Resolucoes.options.Clear();
		for (int i = 0; i < resolutionsSupporteds.Length; i++)
		{
			Resolucoes.options.Add(new Dropdown.OptionData() { text = resolutionsSupporteds[i].width + "x" + resolutionsSupporteds[i].height });

		}
		Resolucoes.captionText.text = "Resolucoes";
	}
	private void AjustarQualidades()
	{
		string[] nomes = QualitySettings.names;
		Qualidades.options.Clear();
		for (int i = 0; i < nomes.Length; i++)
		{
			Qualidades.options.Add(new Dropdown.OptionData() { text = nomes[i] });

		}
		Qualidades.captionText.text = "Qualidades";
	}

	//Void Funcionalidade
	public void Funcionalidades()
	{
		barraVolume.minValue = 0;
		barraVolume.maxValue = 1;

		//Salve
		if (PlayerPrefs.HasKey("Volume"))
		{
			Volume = PlayerPrefs.GetFloat("Volume");
			barraVolume.value = Volume;
		}
		else
		{
			PlayerPrefs.SetFloat("Volume", 1);
			barraVolume.value = 1;
		}

		if (PlayerPrefs.HasKey("modeWindow"))
		{
			modeWindowActive = PlayerPrefs.GetInt("modeWindow");
			if (modeWindowActive == 1)
			{
				Screen.fullScreen = false;
				modeWindow.isOn = true;
			}
			else
			{
				Screen.fullScreen = true;
				modeWindow.isOn = false;
			}
		}
		else
		{
			modeWindowActive = 0;
			PlayerPrefs.SetInt("modeWindow", modeWindowActive);
			modeWindow.isOn = false;
			Screen.fullScreen = true;
		}
		//Resolutions

		if (modeWindowActive == 1)
		{
			screenFullActive = false;
		}
		else
		{
			screenFullActive = true;
		}
		if (PlayerPrefs.HasKey("Resolucoes"))
		{
			resolutionSaveIndex = PlayerPrefs.GetInt("Resolucoes");
            Screen.SetResolution(resolutionsSupporteds[resolutionSaveIndex].width, resolutionsSupporteds[resolutionSaveIndex].height, screenFullActive);
            Resolucoes.value = resolutionSaveIndex;

		}
		else
		{
			resolutionSaveIndex = (resolutionsSupporteds.Length - 1);
			Screen.SetResolution(resolutionsSupporteds[resolutionSaveIndex].width, resolutionsSupporteds[resolutionSaveIndex].height, screenFullActive);
			PlayerPrefs.SetInt("Resolucoes", resolutionSaveIndex);
			Resolucoes.value = resolutionSaveIndex;

		}
		//Qualidades

		if (PlayerPrefs.HasKey("qualidadeGrafica"))
		{
			qualidadeGrafica = PlayerPrefs.GetInt("qualidadeGrafica");
			QualitySettings.SetQualityLevel(qualidadeGrafica);
			Qualidades.value = qualidadeGrafica;
		}
		else
		{
			QualitySettings.SetQualityLevel((QualitySettings.names.Length - 1));
			qualidadeGrafica = (QualitySettings.names.Length - 1);
			PlayerPrefs.SetFloat("qualidadeGrafica", qualidadeGrafica);
			Qualidades.value = qualidadeGrafica;
		}

	}

	//Salvar Preferencias
	public void SalvarPreferencias()
	{
		if (modeWindow.isOn == true)
		{
			modeWindowActive = 1;
			screenFullActive = false;
		}
		else
		{
			modeWindowActive = 0;
			screenFullActive = true;
		}
		PlayerPrefs.SetFloat("Volume", barraVolume.value);
		PlayerPrefs.SetInt("qualidadeGrafica", Qualidades.value);
		PlayerPrefs.SetInt("modeWindow", modeWindowActive);
		PlayerPrefs.SetInt("Resolucoes", Resolucoes.value);
		resolutionSaveIndex = Resolucoes.value;
		AplicarPreferencias();
	}

	//Aplicar Preferencias
	private void AplicarPreferencias()
	{
		Volume = PlayerPrefs.GetFloat("Volume");
		QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("qualidadeGrafica"));
		Screen.SetResolution(resolutionsSupporteds[resolutionSaveIndex].width, resolutionsSupporteds[resolutionSaveIndex].height, screenFullActive);
	}
}
