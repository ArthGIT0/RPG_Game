using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assassin : Enemy
{
    [SerializeField] private int critChance = 20;
    
    public override int Attack()
    {
        Debug.Log("Assassin attacks, chance for critical hit");
        bool isCrit = Random.Range(0, 100) < critChance;
        return isCrit ? Weapon.GetDamage() * 2 : Weapon.GetDamage();
    }
}

