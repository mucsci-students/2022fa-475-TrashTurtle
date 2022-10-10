using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    public PowerupEffect powerupEffect;

    void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.gameObject.name == "BobbertV3"){
            Destroy(gameObject);
            powerupEffect.Apply(collision.gameObject);
        }
    }
}
