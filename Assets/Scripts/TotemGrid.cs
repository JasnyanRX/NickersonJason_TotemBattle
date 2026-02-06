using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotemGrid : MonoBehaviour
{
    public int totemAttack;
    public int totemDefence;
    public string totemAbility;

    public GameObject slot01;
    public GameObject slot02;
    public GameObject slot03;

    // Update is called once per frame
    void Update()
    {
        //Top Slot = Ability
        if (slot01.transform.childCount > 0)
        {
            totemAbility = slot01.transform.GetChild(0).GetComponent<DraggableItem>().ability;
        }
        else
        {
            totemAbility = "None";
        }
        //Middle Slot = Attack
        if (slot02.transform.childCount > 0)
        {
            totemAttack = slot02.transform.GetChild(0).GetComponent<DraggableItem>().attack;
        }
        else
        {
            totemAttack = 0;
        }
        //Bottom Slot = Defence
        if (slot03.transform.childCount > 0)
        {
            totemDefence = slot03.transform.GetChild(0).GetComponent<DraggableItem>().defence;
        }
        else
        {
            totemDefence = 0;
        }

    }
}
