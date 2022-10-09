using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    public PowerupEffect powerupEffect;

    void OnTriggerEnter2D(Collider2D collision)
    {
        // might need to check here that it's a player and not an enemy
        Destroy(gameObject);
        powerupEffect.Apply(collision.gameObject);
    }
}
