using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/HealthBuff")]

public class HealthBuff : PowerupEffect
{
    public int amount;
    private int currentHealth;
    private int totalHealth;

    public override void Apply(GameObject target)
    {
        currentHealth = target.GetComponent<BobbertHealth>().health;
        // Check the heal amount + Bobbert's current health.
        totalHealth = currentHealth + amount;
        
        // If healing would be over health, set it to his max health.
        if(totalHealth >= 7)
        {
            target.GetComponent<BobbertHealth>().health = 7;
        }
        // Else, heal for the amount.
        else
        {
            target.GetComponent<BobbertHealth>().health += amount;
        }
    }
}
