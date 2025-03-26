using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Berserker : Enemy
{
    [SerializeField] private int aggressionGaim = 10; 
    public override int Attack()
    {
        Debug.Log("Berserker attacks");
        aggresion += aggressionGaim;
        return Weapon.GetDamage()+ aggresion / 10;
    }
}
