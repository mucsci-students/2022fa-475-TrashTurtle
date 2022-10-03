using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBehavior : MonoBehaviour
{

    public float Hitpoints;
    public float MaxHitpoints = 5;
    public healthBar healthBar;


    // Start is called before the first frame update
    void Start()
    {
        Hitpoints = MaxHitpoints;
        healthBar.SetHealth(Hitpoints, MaxHitpoints);
    }

    public void TakeHit(float damage){
        Hitpoints -= damage;
        
        if(Hitpoints<= 0){
            Destroy(gameObject);
        }
    }
}
