using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed;

    public Text countText;

    public Text winText;

    public Text livesText;

    private Rigidbody2D rb2d;

    private int count;

    private int countLives;
    private int lives = countLives.ToString();


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D> ();
        count = 0;
        winText.text = "";
        
        livesText.text = "Lives: " + lives;
        countLives = 3;
        livesText.text = "Lives: " + countLives.ToString();
        SetCountText();
        //SetLivesText();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * speed);
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            countLives = countLives - 1;
            SetCountText();
            //SetLivesText();
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 12)
        {
            Vector2 newPosition = transform.position;
            newPosition.x = 100;
            transform.position = newPosition;
            winText.text = "You win! Game created by Theron Harrison.";
        }
        if (countLives = 0)
        {
            winText.text = "You lose!";
        }
           
    }
    //void SetLivesText()
    //{
        //countlivesText.text = "Lives: " + countLives.ToString();
       // if (countLives = 0)
        //{
          // winText.text = "You lose! Game created by Theron Harrison.";
        //}

    //}
}
