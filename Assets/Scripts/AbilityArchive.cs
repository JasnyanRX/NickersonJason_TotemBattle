using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityArchive : MonoBehaviour
{
    public BattleMode battleMode;
    public void ActivateAbility(string AbilityName, int StageOfBattle, TotemGrid totem, string playerOrEnemy)
    {
        if (AbilityName == "None")
        {

        }
        //Blue Moose
        else if (AbilityName == "Thorn Horn" && StageOfBattle == 3)
        {
            if (playerOrEnemy == "player")
            {
                battleMode.enemyPowerInt -= 2;
            }
            if (playerOrEnemy == "enemy")
            {
                battleMode.playerPowerInt -= 2;
            }
        }
        //Green Frog
        else if(AbilityName == "Quick Hops" && StageOfBattle == 2)
        {
            //Attacks twice
            battleMode.BattleStart(playerOrEnemy);
        }
        //Red Bear
        else if (AbilityName == "Grizzly Swipes" && StageOfBattle == 1)
        {
            //Gains +5 attack in battle
            totem.totemAttack += 5;
        }
        //Yellow Bird
        else if (AbilityName == "Birds of a Feather" && StageOfBattle == 1)
        {
            totem.totemAttack += 2;
        }
    }
}
