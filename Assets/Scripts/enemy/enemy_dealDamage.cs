using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_dealDamage : MonoBehaviour
{   
   
    private void OnCollisionEnter2D(Collision2D collision){

        
        if(collision.gameObject.TryGetComponent<BobbertHealth>(out BobbertHealth health)){
            health.TakeDamage(1);
        }
    }
}
