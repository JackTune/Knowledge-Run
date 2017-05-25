using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTxtScript : MonoBehaviour
{
    Text ScoreTxt;

	// Use this for initialization
	void Start ()
    {
        ScoreTxt = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        ScoreTxt.text = "Tempo: " + PlayerScript.Score + "s";
	}
}
