using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class finish_line : MonoBehaviour
{
   void OnTriggerEnter2D(Collider2D collision){
       if(collision.tag == "Player"){
           SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

           
       }
   }
}
