using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private float currentTimeToSpawn;
    private bool teacherSpawned = false;

    [Header("Teacher")]
    public GameObject teacher;
    [Space(20)]
    [Header("Obstacles")]
    public GameObject[] Obstacle;
    [Space(20)]
    [Header("Times")]
    public float minTimeToSpawn;
    public float maxTimeToSpawn;
    public float timeToSpawnTeacher;


    private float timeToSpawn;

    // Use this for initialization
    private void Start()
    {
        currentTimeToSpawn = minTimeToSpawn;
    }

    // Update is called once per frame
    private void Update()
    {

        timeToSpawn = Random.Range(minTimeToSpawn, maxTimeToSpawn + 1);
        
        if (currentTimeToSpawn >= timeToSpawn && !teacherSpawned)
        {
            int random = Random.Range(0, Obstacle.Length);
            Spawn(Obstacle[random]);
            currentTimeToSpawn = 0;
        }
        currentTimeToSpawn += Time.deltaTime;

        if (Time.timeSinceLevelLoad >= timeToSpawnTeacher && !teacherSpawned)
        {
            Spawn(teacher);
            teacherSpawned = true;
        }
    }

    private void Spawn(GameObject prefab)
    {
        float positionX = transform.position.x;
        float positionY;
        try
        {
            positionY = transform.position.y;
        }
        catch (MissingComponentException)
        {
            positionY = transform.position.y;
        }

        Vector3 position = new Vector3(positionX, positionY);

        Instantiate(prefab, this.transform.position/* position*/, Quaternion.identity);
    }
}
