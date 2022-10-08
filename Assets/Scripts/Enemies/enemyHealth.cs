using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{

    public float Hitpoints;
    public float MaxHitpoints = 20;
    public healthBar healthBar;


    // Start is called before the first frame update
    void Start()
    {
        Hitpoints = MaxHitpoints;
        healthBar.SetHealth(Hitpoints, MaxHitpoints);
    }

    public void TakeDamage(int damage){
        Hitpoints -= damage;
        
        if(Hitpoints<= 0){
            Destroy(gameObject);
        }
    }
}
