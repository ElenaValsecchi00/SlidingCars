using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackGround : MonoBehaviour
{
    //variables
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private float height;
    public float speed = -3f;

    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();

        height = coll.size.y;
        rb.velocity = new Vector2(0, speed);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -(height-0.36))
        {
            Reposition();
        }
    }

    //Reposition
    void Reposition()
    {
        Vector2 vector = new Vector2(0, height*3f);
        transform.position = (Vector2)transform.position + vector;
    }
}
