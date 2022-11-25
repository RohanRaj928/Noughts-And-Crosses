using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class gameManager : MonoBehaviour
{

    public UnityEvent<char> gameEnd;

    [Header("Firework Data")]
    public GameObject FireWork;
    public float yLevel;
    public int spawnAmountPerRange;
    public Vector2 spawnRange1; //Defines the two ranges that fireworks can randomly spawn between, left and right of the board
    public Vector2 spawnRange2;


    public char currentTurn { get; private set; } = 'n';
    public bool gameInProgress { get; private set; } = true;


    private void Awake()
    {
        gameInProgress = true;
    }


    public void changeTurn() // A method to SET the current turn to the next player
    {
        if (gameInProgress != true) { Debug.Log("Game is not in progress"); }
        else if (currentTurn == 'n') { currentTurn = 'c'; }
        else { currentTurn = 'n'; }
    }


    public void win(char winner)
    {
        if (gameInProgress == false)
        {
            return;
        }
        gameInProgress = false;
        gameEnd.Invoke(currentTurn);

        gameManager thisComponent = gameObject.GetComponent<gameManager>();
        for (int i = 0; i < spawnAmountPerRange; i++) // Two for loops spawns the fireworks
        {
            Vector2 spawnPos = new Vector2(UnityEngine.Random.Range(spawnRange1.x, spawnRange1.y), yLevel);
            GameObject fw = Instantiate(FireWork, spawnPos, Quaternion.identity); //Quaternion.identity is required if a vector is used for a position instead of a transform.
            fw.GetComponent<firework>().gm = thisComponent;
        }
        for (int i = 0; i < spawnAmountPerRange; i++)
        {
            Vector2 spawnPos = new Vector2(UnityEngine.Random.Range(spawnRange2.x, spawnRange2.y), yLevel);
            GameObject fw = Instantiate(FireWork, spawnPos, Quaternion.identity);
            fw.GetComponent<firework>().gm = thisComponent;
        }

    }

}
