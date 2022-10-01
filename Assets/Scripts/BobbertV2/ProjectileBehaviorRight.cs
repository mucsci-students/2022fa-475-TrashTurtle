using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviorRight : MonoBehaviour
{
    public float speed = 4.5f;
    
    // Update is called once per frame
    private void Update()
    {
        transform.position += -transform.right * Time.deltaTime * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);        
    }
}
