using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestrianSpawner : MonoBehaviour
{
    public GameObject spawnedObject;
    private float wait = 4f; 
    private EnemySpawner es;
    private float lastSpawn;


    // Start is called before the first frame update
    void Start()
    {
        es = GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>();
        StartCoroutine(Spawn());
    }

    void Update()
    {
        lastSpawn = es.lastSpawn;
    }

    //Avoids repetition in Pedestrian Spawning
    float CheckVariationOfSpawns()
    { 
        System.Random rnd = new System.Random();
        int num = rnd.Next(0, 2);
        float x;
        if(lastSpawn == -0.05f)
        {
            x = (num == 0)? 0.85f: -0.9f;
        }
        else if(lastSpawn == 0.85f)
        {
            x = (num == 0)? -0.05f: -0.9f;
        }
        else
        {
            x = (num == 0)? 0.85f: -0.05f;
        }
        return x;   
    }

    //Spawns Pedestrians
    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(1f);
        while (true)
        {
            System.Random rnd = new System.Random();
            float x = CheckVariationOfSpawns();
            Instantiate(spawnedObject, new Vector3(x, 4f, -1f), Quaternion.identity);
            yield return new WaitForSeconds(wait);
        }
    }
}
