using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    public Sprite[] displayHealth;
    Image HP;

   // Use this for initialization
   void Start()
   {

   }
   
   // Update is called once per frame
   void Update ()
   {

   }
 
   //lifebar function to detect sprite loaded in image on canvas in scene
   public void LifeBar(int health)
   {  
        HP = gameObject.GetComponent<Image>();
        HP.sprite = displayHealth[0];
    
        if(health == 6)
        {HP.sprite = displayHealth[1];}
        if(health == 5)
        {HP.sprite = displayHealth[2];}
        if(health == 4)
        {HP.sprite = displayHealth[3];}
        if(health == 3)
        {HP.sprite = displayHealth[4];}
        if(health == 2)
        {HP.sprite = displayHealth[5];}
        if(health == 1)
        {HP.sprite = displayHealth[6];}
   }
}