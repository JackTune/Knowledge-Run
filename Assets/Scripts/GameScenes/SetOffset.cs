using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetOffset : MonoBehaviour
{
    RawImage image;

    [Header("Offset velocity")]
    private static  float speed = 0.5f;
    public static float ImgSize;
    [Space(20)]
    //Prefabs
    [Header("Prefabs")]
    public GameObject door;
    
    public static float Speed
    {
        get
        {
            return -speed;
        }
        set
        {
            speed = value;
        }
    }

    // Use this for initialization
    private void Start()
    {
        speed = 0.5f;
        image = GetComponent<RawImage>();
        Instantiate(door, Vector3.zero, Quaternion.identity);
        ImgSize = image.texture.width / 100;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        //Definindo o offset
        Rect scroll = image.uvRect;
        scroll.x += speed * Time.deltaTime;
        image.uvRect = scroll;
    }
}
