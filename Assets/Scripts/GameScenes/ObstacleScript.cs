using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    Rigidbody2D rb;

    // Use this for initialization
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        rb.velocity = new Vector2(SetOffset.Speed * SetOffset.ImgSize, rb.velocity.y);

        if (transform.position.x < -5)
        {
            Destroy(gameObject);
        }
    }
}
