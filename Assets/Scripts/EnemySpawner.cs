using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //Variables
    public Object spawnedObject;
    private float wait = 2f;
    private GameController gc;
    public EnemyBehaviour eb;
    public RepeatBackGround rb1;
    public RepeatBackGround rb2;
    public RepeatBackGround rb3;
    private int recentSpawns;
    public float lastSpawn;

    // Start is called before the first frame update
    void Start()
    {
        gc = GameObject.Find("gameController").GetComponent<GameController>();
        StartCoroutine(Spawn());
    }

    //Accelerates spawning of enemies
    public void AccelerateSpawn()
    {
        if (wait > 1f && gc.score % 10 == 0) { wait -= 0.20f; Debug.Log(wait); }
        else if (eb.speed > -2.5 && gc.score % 10 == 0) { eb.speed += 0.10f; Debug.Log(eb.speed); rb1.speed += 0.10f; Debug.Log(rb1.speed); rb2.speed += 0.10f; rb3.speed += 0.10f; }
    }

    //Check if too many cars have been spawned in the same position
    float CheckVariationOfSpawns()
    {
        System.Random rnd = new System.Random();
        int num = rnd.Next(0, 3);
        float x = num == 0 ? -0.05f : num == 1 ? -0.9f : 0.85f;
        if (x == lastSpawn && recentSpawns==2)
        {
            x = (x == -0.05f) ? -0.9f : (x == 1f) ? 0.85f : -0.05f;
            recentSpawns = 0;
        }
        else
        {
            if (x == lastSpawn) recentSpawns += 1;
            else recentSpawns = 0;
        }
        lastSpawn = x;
        return x;
    }
    //Coroutine
    IEnumerator Spawn()
    {
        while (true)
        {
            float x = CheckVariationOfSpawns();         
            Instantiate(spawnedObject, new Vector3(x, 4f, -1f), Quaternion.identity);
            yield return new WaitForSeconds(wait);
        }
    }
}
