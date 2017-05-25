using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeacherScript : MonoBehaviour
{
    bool ok;
    public string[] Scenes;
    Rigidbody2D rb;
    
    // Use this for initialization
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rb.velocity = new Vector2(SetOffset.Speed * SetOffset.ImgSize, rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ChangeScene(/*Scenes*/);
        }
    }
    public void ChangeScene(/*string[] Scenes*/)
    {
        SceneManager.LoadScene("Pergunta");
    }
}
