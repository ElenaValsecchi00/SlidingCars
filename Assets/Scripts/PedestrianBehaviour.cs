using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestrianBehaviour : MonoBehaviour
{
    private Object[] spritesArray;
    public float speed = -2f;
    private Rigidbody2D rb;
    private GameController gc;
    private SoundController adSrc;

    // Start is called before the first frame update
    void Start()
    {
        gc = GameObject.Find("gameController").GetComponent<GameController>();
        adSrc = GameObject.Find("SoundController").GetComponent<SoundController>();
        spritesArray = Resources.LoadAll("Pedestrians", typeof(Sprite));
        System.Random rnd = new System.Random();
        int index = rnd.Next(0, spritesArray.Length);
        this.GetComponent<SpriteRenderer>().sprite = Instantiate(spritesArray[index]) as Sprite;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, speed);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            adSrc.PlayClip("pedestrian");
            Destroy(this.gameObject);
            gc.IncreaseScore(2);
        }   
        if(other.tag == "Enemy")
        {
            Destroy(this.gameObject);
        } 
    }
}
