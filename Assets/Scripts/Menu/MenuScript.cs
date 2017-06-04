using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;
using Assets.Scripts;

public class MenuScript : MonoBehaviour
{
    [Header("Menu Inicial")]
    [Space(5)]

    public RawImage BG;
    public Button PlayBT;
    public Button ConfigBT;
    public Texture2D[] BGs;
    public GameObject Inicial;


    [Space(20)]

    [Header("Config. Menu")]
    [Space(5)]

    public Button BackButton, SaveBT;
    public GameObject Configs;

    [Header("Escolher Personagem")]
    [Space(5)]
    public GameObject GOEscolherPersonagem;

    [Header("Objetos do Menu")]
    [Space(5)]

    public Text VideoTxt;
    public Toggle modeWindow;
    private int qualidadeGrafica, modeWindowActive, resolutionSaveIndex;
    public Dropdown Resolucoes, Qualidades;
    private bool screenFullActive;
    private Resolution[] resolutionsSupporteds;
    [Space(5)]

    public Text GameplayTxt;
    public Text CharacterTxt;

    [Space(5)]

    public Text AudioTxt;
    private float Volume;
    public Slider barraVolume;


    [Space(20)]

    [Header("Cenas")]
    [Space(5)]

    public string[] Cenas;

    [Header("Audio")]
    [Space(5)]
    public GameObject audioGO;
    AudioSource audio;

    



    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        DontDestroyOnLoad(audioGO);
        resolutionsSupporteds = Screen.resolutions;
    }
    void Start()
    {
        Opcoes(false);
        
        audio = audioGO.GetComponent<AudioSource>();
    }
    

    public void Opcoes(bool hide)
    {
        if (hide)
            BG.texture = BGs[2];
        else
            BG.texture = BGs[0];

		Funcionalidades();
		ChecarResolucoes();
		AjustarQualidades();


        Inicial.SetActive(!hide);
        Configs.SetActive(hide);
        GOEscolherPersonagem.SetActive(false);
    }

    public void Jogar()
    {
        MyMethods.ChangeScenes(Cenas);
        PlayerScript.TempoInicial = Time.fixedTime;

        audio.Play();
        
    }
    public void EscolherPersonagem()
    {
        BG.texture = BGs[1];
        Inicial.SetActive(false);
        Configs.SetActive(false);
        GOEscolherPersonagem.SetActive(true);
    }

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


    //Update
    void Update()
    {

        if (SceneManager.GetActiveScene().name != "Menu")
        {
            //AudioListener.volume = Volume;
            Destroy(gameObject);
        }
        AudioListener.volume = Volume;
    }
}
