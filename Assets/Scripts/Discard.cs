using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Discard : MonoBehaviour
{
    public List<GameObject> discardPile = new List<GameObject>();
    public GameObject grid;
    public GameObject TotemGrid;
    public Deck deck;
    public TMP_Text text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.SetText(discardPile.Count.ToString());
    }

    public void DiscardCards()
    {
        for (int i = 0; i < 9; i++)
        {
            if (grid.transform.GetChild(i).childCount > 0)
            {
                discardPile.Add(deck.cardsInPlay[i]);
                Destroy(grid.transform.GetChild(i).transform.GetChild(0).gameObject);
                Debug.Log("Destroyed");
            }
        }
        for (int i = 0; i < 3; i++)
        {
            if (TotemGrid.transform.GetChild(i).childCount > 0)
            {
                discardPile.Add(deck.cardsInPlay[i]);
                Destroy(TotemGrid.transform.GetChild(i).transform.GetChild(0).gameObject);
                Debug.Log("Destroyed");
            }
        }
        deck.cardsInPlay.Clear();
    }
}
