using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int health;
    [SerializeField] private Weapon weapon;

    public Weapon Weapon
    {
        get { return weapon; }
    }

    public virtual int Attack()
    {
        return weapon.GetDamage();
    }

    // Make this method virtual so that it's overridden in child classes
    public virtual void GetHit(int damage)
    {
        // Debug the incoming damage
        Debug.Log($"{name} starting health: {health} | Received damage: {damage}");
        health -= damage;
        Debug.Log($"{name} health after hit: {health}");
    }

    public void GetHit(Weapon weapon)
    {
        Debug.Log($"{name} starting health: {health} | Received damage from weapon: {weapon.GetDamage()}");
        health -= weapon.GetDamage();
        Debug.Log($"{name} health after hit by {weapon.name}: {health}");
    }
}