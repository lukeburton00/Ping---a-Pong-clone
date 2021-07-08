using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    public int winningScore;
    public int service;
    public Vector3 movement;
    public float speedX;
    public float speedY;
    public GameObject endScreen;
    private int scoreOne = 0;
    private int scoreTwo = 0;
    public Text scoreOneText;
    public Text scoreTwoText;
    public Text winner;
    public GameObject playerOne;
    public GameObject playerTwo;
    public GameObject gameMaster;
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        StartCoroutine(Service());
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += movement * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        float reflectionSpeed = 0.5f;

        if (movement.x > 0)
        {
            movement.x += reflectionSpeed;
        }
        if (movement.x < 0)
        {
            movement.x -= reflectionSpeed;
        }

        float playerCenter = other.transform.position.y;
        float ballCenter = gameObject.transform.position.y;
        float centerPadding = 0.01f;

        if (other.tag == "Player")
        {
            if (ballCenter < (playerCenter + centerPadding) && ballCenter > playerCenter - centerPadding)
            {
                movement.x *= -1;
                movement.y *= -1;
    
            }

            if (ballCenter > playerCenter + centerPadding)
            {
                movement.x *= -1;
                movement.y = Mathf.Abs(playerCenter - ballCenter) * Mathf.Abs(movement.x);
            }

            if (ballCenter < playerCenter - centerPadding)
            {
                movement.x *= -1;
                movement.y = Mathf.Abs(playerCenter - ballCenter) * Mathf.Abs(movement.x) * -1;

            }
        }

        if (other.tag == "Boundary")
        {
            movement.y *= -1;
        }

        if (other.tag == "Goal")
        {
            if (movement.x < 0)
            {
                scoreTwo ++;
                scoreTwoText.text = scoreTwo.ToString();
            }

            if (movement.x > 0)
            {
                scoreOne ++;
                scoreOneText.text = scoreOne.ToString();
            }

            StartCoroutine(Service());
            if (scoreOne == winningScore)
            {
                Time.timeScale = 0f;
                
                winner.text = "Left Player wins!";
                endScreen.SetActive(true);
                Time.timeScale = 0f;
                Cursor.visible = true;
            }

            if (scoreTwo == winningScore)
            {
                winner.text = "Right Player wins!";
                endScreen.SetActive(true);
                Time.timeScale = 0f;
                Cursor.visible = true;
            }
        }
    }

    IEnumerator Service()
    {
        yield return new WaitForSecondsRealtime(1);
        playerTwo.transform.position = new Vector3 (playerTwo.transform.position.x, 0);
        playerOne.transform.position = new Vector3 (playerOne.transform.position.x, 0);

        speedX = 10;
        speedY = 0;
        service *= -1;
        movement = new Vector3(speedX, speedY) * service;
        Vector3 center = new Vector3(0,0,0);
        gameObject.transform.position = center;

    }
}
