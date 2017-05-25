using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    Rigidbody2D rb;
    RaycastHit2D[] hitInfo;
    Button botao;
    bool hit;
    [Header("Jump")]
    [Space(5)]
    public float jumpForce;
    [Space(20)]
    public static bool isDead;
    bool onGround;

    [Header("LineCast")]
    [Space(5)]
    public Transform StartLine;
    public Transform EndLine;


    private static decimal score;
    public static decimal Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
        }
    }

    private static float tempoInicial;
    public static float TempoInicial
    {
        get
        {
            return tempoInicial;
        }
        set
        {
            tempoInicial = value;
            
        }
    }

    // Use this for initialization
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isDead = false;
    }
    private void Update()
    {
		Jump();
        score = decimal.Round(Convert.ToDecimal(Time.fixedTime - TempoInicial), 2);
        
        if (isDead)
        {
            SetOffset.Speed = 0;
            SceneManager.LoadScene("Hitted");
        }
    }
		

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && onGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        string tag = collision.gameObject.tag;

        //Verificando se o player bateu ao lado do obstáculo ou parou em cima dele
        hit = Physics2D.Linecast(StartLine.position, EndLine.position, 1 << LayerMask.NameToLayer("Obstacles"));

        if (tag == "Ground")
        {
            onGround = true;
        }
        else if (tag == "Obstacle" && hit)
        {
            isDead = true;
            print("Bateu no obstáculo");
        }
        else if (tag == "Obstacle" && !hit)
        {
            onGround = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        string tag = collision.gameObject.tag;

        //Verificando se o personagem saiu do chão
        if (tag == "Ground" || tag == "Obstacle")
        {
            onGround = false;
        }
        else
        {
            onGround = true;
        }
    }
}
