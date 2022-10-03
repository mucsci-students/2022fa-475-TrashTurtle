using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobbertDamage : MonoBehaviour
{
    public int damage;
    public MonsterHealth monsterHealth;
    // Start is called before the first frame update

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
           monsterHealth.TakeDamage(damage);
        }
    }
}
