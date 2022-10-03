using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotHandler : MonoBehaviour
{
    Rigidbody2D rb;
    bool hasCollided;
    float deleteTimer = 1.5f;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!hasCollided)
        {
            float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

   private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag != "Enemy"){
            Destroy(gameObject, deleteTimer);
        }
        
        if(collision.gameObject.TryGetComponent<enemyBehavior>(out enemyBehavior health)){
            health.TakeDamage(1);
        }
    }
}
