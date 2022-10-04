using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDamage : MonoBehaviour
{

   private void OnCollisionEnter2D(Collision2D collision){
       
        if(collision.gameObject.TryGetComponent<BobbertHealth>(out BobbertHealth Health)){
            Health.TakeDamage(1);
        }
    }
}
