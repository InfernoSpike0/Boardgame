using UnityEngine;
using System.Collections.Generic;

[System.Serializable]   // lets you view/edit in Inspector if stored in GameBase
public class Player
{
    public int id;                // Unique ID 
    public int playerNumber;      // Turn order number
    public int score;             // Turrent score
    public Color color;           // Player color
    public Dictionary<string, int> currencies; // In-game currencies

    public Player(int id, Color color, int number = 0)
    {
        this.id = id;
        this.color = color;
        this.playerNumber = number == 0 ? id : number;
        this.score = 0;

        currencies = new Dictionary<string, int>
        {
            { "money1", 0 },
            { "money2", 0 },
            { "money3", 0 },
            { "money4", 0 },
            { "money5", 0 },
            { "joker", 0 }
        };
    }

    public void AddCurrency(string currency, int amount)
    {
        if (!currencies.ContainsKey(currency))
            currencies[currency] = 0;

        currencies[currency] += amount;
    }

    public override string ToString()
    {
        return $"Player {id} (Color: {color}, Score: {score})";
    }
}