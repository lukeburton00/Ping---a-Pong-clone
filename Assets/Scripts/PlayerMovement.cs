using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject playerOne;
    public GameObject playerTwo;
    public float movementSpeed;
    public GameObject ball;
    private GameObject gameMaster;
    private bool isSinglePlayer;
    private float moveBounds = 3.93f;
    private int speedAdvantage = 2;
    // Update is called once per frame

    private void Start() {

        //Get game mode from Game Master
        gameMaster = GameObject.FindGameObjectWithTag("GameController");
        isSinglePlayer = gameMaster.GetComponent<GameMaster>().isSinglePlayer;
    }

    void Update()
    {
        Vector3 move = new Vector3 (0,movementSpeed);

        //Player One Movement
        if (Input.GetKey(KeyCode.W) && playerOne.transform.position.y < moveBounds)
        {
            playerOne.transform.position += move * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S) && playerOne.transform.position.y > -moveBounds){
            playerOne.transform.position += move * Time.deltaTime * -1;
        }

        //Check the game mode and move players accordingly
        if (isSinglePlayer)
        {
            MoveAI();
        }

        if (!isSinglePlayer)
        {
            MovePlayerTwo(move);
        }
    }

    void MoveAI()
    {
        //Get ball position and AI Player position
        Vector3 ballPosition = ball.transform.position;
        Vector3 AIPosition = playerTwo.transform.position;

        //Give AI a speed advantage
        Vector3 AIMove = new Vector3(0,movementSpeed + speedAdvantage);
        
        //AI Movement - move paddle towards ball
        if (AIPosition.y < ballPosition.y && AIPosition.y < moveBounds)
        {
            playerTwo.transform.position += AIMove * Time.deltaTime;
        }

        if (AIPosition.y > ballPosition.y && AIPosition.y > -moveBounds)
        {
            playerTwo.transform.position += AIMove * Time.deltaTime * -1;
        }
    }

    void MovePlayerTwo(Vector3 move)
    {
         //Player Two Movement
        if (Input.GetKey(KeyCode.UpArrow) && playerTwo.transform.position.y < moveBounds)
        {
            playerTwo.transform.position += move * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.DownArrow) && playerTwo.transform.position.y > -moveBounds){
            playerTwo.transform.position += move * Time.deltaTime * -1;
        }
    }
}
