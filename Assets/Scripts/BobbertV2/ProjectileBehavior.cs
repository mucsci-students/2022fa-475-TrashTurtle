using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ProjectileBehavior : MonoBehaviour{
   
   public float speed = 4.5f;
   public bool direction;
   private Animator m_Anim;

    public void Awake()
    {
        m_Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        //m_Anim.GetBool("facingRight")
        // If(Input.GetAxis("Horizontal"))
        // {
        //     transform.position += -transform.right * Time.deltaTime * speed;
        // }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);        
    }
}