using UnityEngine;

public class background : MonoBehaviour
{
    public Transform mainCam;
    public Transform midBG;
    public Transform sideBG;
  
    public float length = 41.23f;
    void Update()
    {
        if(mainCam.position.x > midBG.position.x){
            sideBG.position = midBG.position + Vector3.right * length;
        }
        if(mainCam.position.x < midBG.position.x){
            sideBG.position = midBG.position + Vector3.left * length;
        }
    }



}