using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscolherPersonagem : MonoBehaviour
{
    public GameObject[] Personagens;
    GameObject PersonagemEscolhido;
    Rigidbody2D playerRB;
    int index;

    // Use this for initialization
    void Start ()
    {
        index = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (PersonagemEscolhido == null)
        {
            PersonagemEscolhido = Instantiate(Personagens[index]);
            playerRB = PersonagemEscolhido.GetComponent<Rigidbody2D>();
            playerRB.gravityScale = 0;

            PlayerPrefs.SetInt("Personagem", index);
        }
        
	}

    public void ChangeIndex(int index)
    {
        this.index = index;
        Destroy(PersonagemEscolhido);
        PersonagemEscolhido = Instantiate(Personagens[index]);
        playerRB = PersonagemEscolhido.GetComponent<Rigidbody2D>();
        playerRB.gravityScale = 0;

        PlayerPrefs.SetInt("Personagem", index);
    }
}
