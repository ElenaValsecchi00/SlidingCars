using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    //variables
    private Rigidbody2D rb;
    public Transform tr;
    private SoundController adSrc;
    public GameObject pauseButton;
    public TextMeshProUGUI gameOver;
    public TextMeshProUGUI yourScore;
    public TextMeshProUGUI yourScoreText;
    public GameController gc;

    private float startPos = 0;
    private float endPos = 0;
    private bool slide = false;
    private bool hasBeenTouched = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tr = GetComponent<Transform>();
        adSrc = GameObject.Find("SoundController").GetComponent<SoundController>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    //Movement
    void Movement()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (RectTransformUtility.RectangleContainsScreenPoint(pauseButton.GetComponent<RectTransform>(), Input.mousePosition)) return;
            startPos = Input.mousePosition.x;
            hasBeenTouched = true;
        }

        if (Input.mousePosition.x!=startPos && hasBeenTouched)
        {
            endPos = Input.mousePosition.x;
            slide = true;
            hasBeenTouched = false;
        }

        if(slide)
        {
            if (startPos > endPos && startPos != 0 && endPos != 0 && transform.position.x != -0.9f)
            {
                Vector3 vector = new Vector3(0.9f, 0, 0);
                transform.position = transform.position - vector;
            }

            else if (startPos < endPos && startPos != 0 && endPos != 0 && transform.position.x != 0.9f)
            {
                Vector3 vector = new Vector3(0.9f, 0, 0);
                transform.position = transform.position + vector;
            }

            slide = false;
        }
                
    }

    //Collision with Enemy
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag=="Enemy")
        {
            adSrc.PlayClip("death");
            gameOver.gameObject.SetActive(true);
            yourScore.gameObject.SetActive(true);
            yourScoreText.text = gc.score.ToString();
            yourScoreText.gameObject.SetActive(true);
            StartCoroutine(EndCoroutine());         
        }
    }

    IEnumerator EndCoroutine()
    {
        yield return new WaitForSeconds(0.1f);
        Thread.Sleep(2000);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Debug.Log("GameOver");
    }
}
