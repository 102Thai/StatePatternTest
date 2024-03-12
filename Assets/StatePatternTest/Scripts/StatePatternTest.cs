using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatePatternTest : MonoBehaviour
{
    public PlayerAttackStates playerStates;

    //this method is called in button on hierachy
    public void Attack()
    {
        if (playerStates == PlayerAttackStates.AttackOnAir)
        {
            Debug.Log("player is attack on the air");
        }else if( playerStates==PlayerAttackStates.AttackOnGround)
        {
            Debug.Log("player is attack on the ground");
        }else if(playerStates==PlayerAttackStates.AttackUnderground)
        {
            Debug.Log("player is attack under the ground");
        }else if(playerStates==PlayerAttackStates.AttackUnderSea)
        {
            Debug.Log("player is attack under the sea");
        }
    }


}
public enum PlayerAttackStates
{
    AttackOnAir,
    AttackOnGround,
    AttackUnderground,
    AttackUnderSea
}