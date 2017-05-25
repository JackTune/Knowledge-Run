using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    Rigidbody2D rb;


    // Use this for initialization
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(SetOffset.Speed * SetOffset.ImgSize, 0);
    }

    // Update is called once per frame
    private void Update()
    {
        if (transform.position.x < -12)
        {
            Destroy(gameObject);
        }
    }
}
