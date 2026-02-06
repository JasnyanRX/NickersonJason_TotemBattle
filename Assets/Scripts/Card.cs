using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card
{
    public int id;
    public string nameOfCard;
    public string type;
    public Color color;
    public string ability;
    public int attack;
    public int defence;

    // Start is called before the first frame update
    public Card()
    {

    }

    public Card(int cardId, string cardName, string cardType, Color cardColor, string cardAbility, int cardAttack, int cardDefence)
    {
        id = cardId;
        nameOfCard = cardName;
        type = cardType;
        color = cardColor;
        ability = cardAbility;
        attack = cardAttack;
        defence = cardDefence;
    }
}
