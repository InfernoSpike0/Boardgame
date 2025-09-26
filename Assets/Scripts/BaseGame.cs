using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class GameBase : MonoBehaviour
{
    [Header("Players")]
    public int playerCount = 4;   // set from menu
    public List<Player> players = new List<Player>();

    [Header("Turn Logic")]
    public int currentTurn = 1;   // 1 = Player1’s turn

    [Header("Debug")]
    public bool debug = true;

    void Start()
    {
        // Create players based on playerCount
        for (int i = 1; i <= playerCount; i++)
        {
            players.Add(new Player(i));
        }

        if (debug)
        {
            Debug.Log("Game started! Player " + currentTurn + " begins.");
        }
    }

    public void TurnEnd()
    {
        currentTurn++;

        // Wrap turn around
        if (currentTurn > playerCount)
        {
            currentTurn = 1;
        }

        if (debug)
        {
            Debug.Log("It's now Player " + currentTurn + "'s turn!");
        }
    }
}