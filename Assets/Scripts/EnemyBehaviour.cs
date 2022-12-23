using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    //varables
    private static Object[] spritesArray;
    private Rigidbody2D rb;
    public float speed = -2f;
    private PlayerMovement player;
    private GameController gameC;
    private SoundController adSrc;
    //Awake
    void Awake()
    {
        if (spritesArray == null)
        {
            spritesArray = Resources.LoadAll("EnemySprites", typeof(Sprite));
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        System.Random rnd = new System.Random();
        int index = rnd.Next(0, spritesArray.Length);
        this.GetComponent<SpriteRenderer>().sprite = Instantiate(spritesArray[index]) as Sprite;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, speed);
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
        gameC = GameObject.Find("gameController").GetComponent<GameController>();
        adSrc = GameObject.Find("SoundController").GetComponent<SoundController>();
    }

    // Update is called once per frame
    void Update()
    {
        IncreaseScore();
    }

    //Inscrease Score
    void IncreaseScore()
    {
        if(transform.position.y<player.tr.position.y-0.5)
        {
            adSrc.PlayClip("point");
            gameC.IncreaseScore();
            Destroy(gameObject);
        }

    }
}
