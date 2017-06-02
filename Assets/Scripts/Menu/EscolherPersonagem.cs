using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscolherPersonagem : MonoBehaviour
{
    public GameObject[] Personagens;
    GameObject PersonagemEscolhido;
    int index;

	// Use this for initialization
	void Start ()
    {
        index = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!PersonagemEscolhido)
        {
            PersonagemEscolhido = Personagens[index];
        }
		
	}

    public void ChangeIndex(int index)
    {
        this.index = index;
    }
}
