using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Card
{
    public string CardName;
    public int CardID;
    public string CardDes;
    public Texture2D CardIcon;

    public Card()
    {

    }
    public Card(string name, int id, string desc)
    {
        CardName = name;
        CardID = id;
        CardDes = desc;
        CardIcon = Resources.Load<Texture2D>("Sprites/" + name);
    }

   
}
