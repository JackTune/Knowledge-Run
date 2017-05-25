using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using Assets.Scripts;

public class RunningAgain : MonoBehaviour
{
    public string[] Scenes;
    
    private void Start()
    {
        StartCoroutine(DelayObstaculo(2));       
    }
    IEnumerator DelayObstaculo(int segundos)
    {
        yield return new WaitForSeconds(segundos);
        SceneManager.LoadScene(MyMethods.LastScene);
    }
}
