using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHealth : MonoBehaviour
{
    public int maxHealth = 40;
    public int health;
    
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Other enemies call this function
    public void TakeDamage(int dmg)
    {
        health -= dmg;
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
