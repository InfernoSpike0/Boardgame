using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Player : MonoBehaviour
{
    public int playerNumber;
    public int score;
    public Dictionary<string, int> currencies;

    public Player(int number)
    {
        playerNumber = number;
        score = 0;
        currencies = new Dictionary<string, int>
        {
            { "money1", 0 },
            { "money2", 0 },
            { "money3", 0 },
            { "money4", 0 },
            { "money5", 0 }
        };
    }

    public void AddCurrency(string currency, int amount)
    {
        currencies[currency] += amount;
    }
}
