using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BattleMode : MonoBehaviour
{
    public GameObject playerTotemOBJ;
    public GameObject enemyTotemOBJ;
    public GameObject totemBuild;

    public TotemGrid playerTotem;
    public TotemGrid enemyTotem;

    public TMP_Text playerPowerText;
    public TMP_Text enemyPowerText;
    public int playerPowerInt = 0;
    public int enemyPowerInt = 0;

    bool isSetUp = false;
    int StageOfBattle = 1;
    int timer = 0;
    float battleTimer = 0;

    public AbilityArchive abilityArchive;
    public GameObject builder;
    public Discard discard;

    public CardDatabase cardDatabase;

    // Update is called once per frame
    void Update()
    {
        timer++;
        if (!isSetUp && timer > 10)
        {
            playerPowerInt = playerTotem.totemAttack + playerTotem.totemDefence;
            enemyPowerInt = enemyTotem.totemAttack + enemyTotem.totemDefence;
            isSetUp = true;
        }
        playerPowerText.SetText(playerPowerInt.ToString());
        enemyPowerText.SetText(enemyPowerInt.ToString());

        if (isSetUp)
        {
            battleTimer += Time.deltaTime;
        }
        //Before Combat
        if (isSetUp && StageOfBattle == 1 && battleTimer >= 0.5)
        {
            CheckAbilities(1);
            Debug.Log("Stage 1");
            StageOfBattle = 2;
        }
        //During Combat
        if (StageOfBattle == 2 && battleTimer >= 2)
        {
            BattleStart("player");
            BattleStart("enemy");
            CheckAbilities(2);
            Debug.Log("Stage 2");
            StageOfBattle = 3;
        }
        //After Combat
        if (StageOfBattle == 3 && battleTimer >= 3)
        {
            CheckAbilities(3);
            Debug.Log("Stage 3");
            StageOfBattle = 4;
        }
        //Reset
        if (StageOfBattle == 4 && battleTimer >= 4)
        {
            builder.SetActive(true);
            discard.DiscardCards();
            RemoveGrids();
            isSetUp = false;
            timer = 0;
            battleTimer = 0; 
            StageOfBattle = 1;
            this.gameObject.SetActive(false);
        }
    }

    public void SetUpTotem()
    {
        Instantiate(totemBuild.transform.GetChild(0).transform.GetChild(0).gameObject, playerTotemOBJ.transform.GetChild(0));
        Instantiate(totemBuild.transform.GetChild(1).transform.GetChild(0).gameObject, playerTotemOBJ.transform.GetChild(1));
        Instantiate(totemBuild.transform.GetChild(2).transform.GetChild(0).gameObject, playerTotemOBJ.transform.GetChild(2));

        timer = 0;
        isSetUp = false;
    }

    public void BattleStart(string totem)
    {
        if (isSetUp)
        {
            //Enemy Attacks
            if (totem == "enemy")
                playerPowerInt = playerPowerInt - (enemyTotem.totemAttack - playerTotem.totemDefence);
            //Player Attacks
            if (totem == "player")
                enemyPowerInt = enemyPowerInt - (playerTotem.totemAttack - enemyTotem.totemDefence);
        }
    }

    public void CheckAbilities(int StageOfBattle)
    {
        abilityArchive.ActivateAbility(playerTotem.totemAbility, StageOfBattle, playerTotem, "player");
        abilityArchive.ActivateAbility(enemyTotem.totemAbility, StageOfBattle, enemyTotem, "enemy");
    }

    public void RandomizeEnemyGrid()
    {
        int x = 0;
        for (int i = 0; i < 3; i++)
        {
            x = Random.Range(0, 3);
            Instantiate(cardDatabase.cardList[x], enemyTotemOBJ.transform.GetChild(i));
        }
    }

    public void RemoveGrids()
    {
        for (int i = 0; i < 3; i++)
        {
            if (playerTotemOBJ.transform.GetChild(i).childCount > 0)
            {
                Destroy(playerTotemOBJ.transform.GetChild(i).transform.GetChild(0).gameObject);
            }
            if (enemyTotemOBJ.transform.GetChild(i).childCount > 0)
            {
                Destroy(enemyTotemOBJ.transform.GetChild(i).transform.GetChild(0).gameObject);
            }
        }
    }
}
