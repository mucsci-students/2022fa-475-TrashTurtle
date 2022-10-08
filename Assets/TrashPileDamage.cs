using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashPileDamage : MonoBehaviour
{   
   
    private void OnCollisionEnter2D(Collision2D collision){

        
        if(collision.gameObject.TryGetComponent<BobbertHealth>(out BobbertHealth health)){
            health.UpdateHealth(-100);
        }
    }
}
