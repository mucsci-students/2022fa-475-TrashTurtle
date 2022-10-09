using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class enemyGFX : MonoBehaviour
{
    // Start is called before the first frame update
   
    public AIPath aiPath;
    // Update is called once per frame
    void Update()
    {
      
        if(aiPath.desiredVelocity.x >= 0.01f ){
            transform.localScale = new Vector3(.4f, .4f, 0f);
        }
        else if( aiPath.desiredVelocity.x <= -0.01f){
            transform.localScale = new Vector3(.4f, .4f, 0f);
        }
    }
}

