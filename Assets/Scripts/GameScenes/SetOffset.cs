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
    public GameObject[] Personagens;
    
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
        int index = PlayerPrefs.GetInt("Personagem");
        Instantiate(Personagens[index]);

        image = GetComponent<RawImage>();
        ImgSize = image.texture.width / 100;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        //Definindo o offset
        Rect scroll = image.uvRect;
        scroll.x += speed * Time.deltaTime;
        image.uvRect = scroll;

        speed += 0.00005f;
        //Debug.Log(speed);
    }
}
