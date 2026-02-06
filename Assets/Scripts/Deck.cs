using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Deck : MonoBehaviour
{
    public List<GameObject> deck = new List<GameObject>();
    public int x;
    public int deckAmount = 30;
    public CardDatabase totemPieceDatabase;
    public GameObject Grid;
    public TMP_Text text;
    public Discard discard;

    public List<GameObject> cardsInPlay = new List<GameObject>();

    // Start is called before the first frame update
    void Awake()
    {
        x = 0;
        for (int i = 0; i < deckAmount; i++)
        {
            x = Random.Range(0, totemPieceDatabase.cardList.Count);
            deck[i] = totemPieceDatabase.cardList[x];
        }
        DrawCards(6);
    }

    // Update is called once per frame
    void Update()
    {
        text.SetText(deck.Count.ToString());
    }

    public void DrawCards(int drawAmount)
    {
        for (int i = 0;i < drawAmount;i++)
        {
            if (Grid.transform.GetChild(i).childCount == 0)
            {
                Instantiate(deck[i], Grid.transform.GetChild(i).transform);
                cardsInPlay.Add(deck[i]);
                deck.RemoveAt(i);
            } 
        }
    }

    public void ShuffleCard()
    {
        for (int i = 0; i < deck.Count; i++)
        {
            GameObject temp = deck[i];
            int rand = Random.Range(i, deck.Count);
            deck[i] = deck[rand];
            deck[rand] = temp;
        }
    }

    public void ResetDeck()
    {
        for (int i = discard.discardPile.Count - 1; i >= 0; i--)
        {
            deck.Add(discard.discardPile[i]);
            discard.discardPile.RemoveAt(i);
        }
    }
}
