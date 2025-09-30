using UnityEngine;
using System.Collections.Generic;

public class GameBase : MonoBehaviour
{
    [Header("Players")]
    public int playerCount = 4;                  // configurable in Inspector
    public List<Player> players = new List<Player>();

    [Header("Turn Logic")]
    public int currentTurn = 1;                  // 1 = Player1’s turn

    [Header("Debug")]
    public bool debug = true;

    void Start()
    {
        GameStart();
    }

    void GameStart()
    {
        // Base palette (add more or generate if > 4 players)
        Color[] playerColors = { Color.red, Color.blue, Color.green, Color.yellow };

        players.Clear();

        // Create players with unique ids and colors
        for (int i = 1; i <= playerCount; i++)
        {
            Color c = (i <= playerColors.Length) 
                ? playerColors[i - 1] 
                : Color.HSVToRGB((i - 1f) / playerCount, 0.85f, 0.95f); // auto-generate distinct colors if > 4 players

            players.Add(new Player(i, c));
        }

        currentTurn = Mathf.Clamp(currentTurn, 1, playerCount);

        if (debug)
        {
            Debug.Log("Game started! Player " + currentTurn + " begins.");
        }
    }

    public Player GetCurrentPlayer()
    {
        if (players == null || players.Count == 0) return null;
        return players[Mathf.Clamp(currentTurn - 1, 0, players.Count - 1)];
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
