using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boardManager : MonoBehaviour
{
    // n is a nought
    // c is a cross
    // z is neither
    public gameManager gameManager;


    [Header("Board Settings")]
    [SerializeField]
    private char[] counterPositions = new char[9];
    public Rect[] possiblePositions = new Rect[9];

    [Header("Item Settings")]
    public GameObject nought;
    public GameObject noughtParticle;
    public GameObject cross;
    public GameObject crossParticle;


    private void Start()
    {
        for (int i = 0; i < 9; ++i) { counterPositions[i] = 'z'; } // Fills the array counterPositions with the value z
    }

    public bool placeCounter(char counter, int pos)
    {

        if (counterPositions[pos] != 'z') {return false; }
        else if(counter == 'n') {
            counterPositions[pos] = 'n';
            Instantiate(nought, new Vector2(possiblePositions[pos].x + 1, possiblePositions[pos].y + 1), Quaternion.identity);
            Instantiate(noughtParticle, new Vector2(possiblePositions[pos].x + 1, possiblePositions[pos].y + 1), Quaternion.identity);

            return true;
        }
        else if(counter == 'c') {
            counterPositions[pos] = 'c';
            Instantiate(cross, new Vector2(possiblePositions[pos].x + 1, possiblePositions[pos].y + 1), Quaternion.identity);
            Instantiate(crossParticle, new Vector2(possiblePositions[pos].x + 1, possiblePositions[pos].y + 1), Quaternion.identity);
            return true;
        }
        else { throw new System.ArgumentException("Input must be 'z' or 'c'"); }

        

    }

    public bool detectWin(char player, int recentPosition)
    {
        char currentTurn = gameManager.currentTurn;
        int[,] winPositions = new int[,] { {0,1,2},{3,4,5},{6,7,8},{0,3,6},{1,4,7},{2,5,8},{0,4,8},{6,4,2}};

        for (int i = 0; i < 8; i++)
        {
           if (counterPositions[winPositions[i,0]] == player & counterPositions[winPositions[i,1]] == player & counterPositions[winPositions[i, 2]] == player)
            {
                return true;
            }
        }
        return false;

    }
    //
    private void OnMouseDown()
    {
        Debug.Log(gameManager.gameInProgress);
        if (gameManager.gameInProgress == true) { // Ensures the game has not ended before running the code
        // A vector2 storing the mouse x and y position.
        Vector2 mousePos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);

        for (int i = 0; i < 9; i++)
        {
             if (possiblePositions[i].Contains(mousePos))
                {

                    if (placeCounter(gameManager.currentTurn, i) == true)
                    {

                        if (detectWin(gameManager.currentTurn, i) == true)
                        {
                            gameManager.win(gameManager.currentTurn);
                        }
                        else { gameManager.changeTurn(); }


                    }
                    else { Debug.Log("Counter cannot be placed there"); }

                }   

        }  
    }
    }



}
