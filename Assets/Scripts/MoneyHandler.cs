using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class MoneyHandler : MonoBehaviour
{
    public bool debug = false;
    private bool hasDrawn = false;
    public List<int> cardsChosen = new List<int>();

    // This list holds the chosen cards. It goes 0-4 = money1-5. I don't really know what to do with jokers, but hopefully we get to work that out.

    void Start()
    {
        if (debug && !hasDrawn)
        {
            ChooseCards();
            Debug.Log("Cards drawn: " + string.Join(", ", cardsChosen));
            hasDrawn = true;
        }
    }
    void ChooseCards()
    {
        cardsChosen.Clear();
        for (int i = 0; i <= 4; i++)
        {
            int cards = Random.Range(1, 82);

            if (cards == 81)
            {
                cardsChosen.Add(81);
            }
            else
            {
                int moneyType = cards % 5;
                cardsChosen.Add(cards);
            }
        }
        hasDrawn = true;
    }

    void DrawCards()
    {
        
    }

}
