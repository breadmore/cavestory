using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDataBase : MonoBehaviour
{
    public List<Card> cards = new List<Card>();

    void Start()
    {
        cards.Add(new Card("Hall", 1001, "Hall"));
        cards.Add(new Card("House", 1002, "House"));
        cards.Add(new Card("Mine", 1003, "Mine"));
        cards.Add(new Card("Temple", 1004, "Temple"));
    }
}
