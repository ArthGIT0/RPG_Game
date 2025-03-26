using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : Enemy
{
    [SerializeField] private int armor = 5;

    // Override GetHit to apply armor to incoming damage
    public override void GetHit(int damage)
    {
        // Calculate the final damage after applying armor
        int finalDamage = Mathf.Max(damage - armor, 0); // Ensure the damage is never negative
        
        // Log the damage calculation
        Debug.Log($"{name} received {damage} damage (armor: {armor}), final damage: {finalDamage}");

        // Call the base GetHit method with the final damage
        base.GetHit(finalDamage);
    }

    public override int Attack()
    {
        // Calculate and return the damage for the tank's attack, factoring in armor
        int rawDamage = Weapon.GetDamage();
        int finalDamage = Mathf.Max(rawDamage - armor, 1);  // Armor reduces damage for the attack
        Debug.Log($"Tank attacks with {rawDamage} damage, after armor: {finalDamage}");
        return finalDamage;
    }
}