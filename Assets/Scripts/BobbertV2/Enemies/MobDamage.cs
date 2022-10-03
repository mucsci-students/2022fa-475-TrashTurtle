using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobDamage : MonoBehaviour
{
    public int damage;
    public BobbertHealth bobbertHealth;
    // Start is called before the first frame update

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
           bobbertHealth.TakeDamage(damage);
        }
    }

}
