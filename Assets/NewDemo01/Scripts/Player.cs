using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHP;
    public int currentHP;
    public int damage;

    public string Name;

    public bool TakeDamage(int damage)
    {
        currentHP -= damage;
        if (currentHP <= 0)
            return true;
        else 
            return false;
    }

    public void HealHP(int hp)
    {
        currentHP += hp;
    }
}
