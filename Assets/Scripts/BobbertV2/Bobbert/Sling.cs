using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sling : MonoBehaviour
{ 
    Transform firstChild;
    Vector3 changeScale;
    Vector2 direction;
    GameObject[] points;
    
    public Transform shotPoint;
    public GameObject shot;
    public GameObject player;
    public GameObject point;
    public float spaceBetweenPoints;
    public float launchForce;
    public bool isLeft;
    public int numberOfPoints;

    // Generates the prefab of opaque turtle shell a bunch of times.
    private void Start() {
        points = new GameObject[numberOfPoints];

        for (int i = 0; i < numberOfPoints; i++)
        {
            points[i] = Instantiate(point, shotPoint.position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        isLeft = false;
        //firstChild = GameObject.Find("Sling").transform.GetChild(1);
        //Debug.Log(firstChild.name);
        Vector2 slingPosition = transform.position;
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);


        for(int i = 0; i < numberOfPoints; i++)
            {
                points[i].transform.position = PointPosition(i * spaceBetweenPoints);
            }
        
        if(player.transform.localScale.x == 1)
        {
            if(mousePos.x > player.transform.position.x && mousePos.y > player.transform.position.y)
            {    
                direction = mousePos - slingPosition;
                transform.right = direction;
                if(Input.GetMouseButtonDown(0)) { Shoot(); }
            }
        }

        if(player.transform.localScale.x == -1)
        {        
            if(mousePos.x < player.transform.position.x && mousePos.y > player.transform.position.y)
            {
                direction = mousePos - slingPosition;
                transform.right = direction;
                if(Input.GetMouseButtonDown(0)) { Shoot(); }
            }
        }
    }

    // Pew pew time.
    void Shoot() {
        GameObject newShot = Instantiate(shot, shotPoint.position, shotPoint.rotation);
        newShot.GetComponent<Rigidbody2D>().velocity = transform.right * launchForce;
    }

    // Where to place the points showing the trajectory.
    Vector2 PointPosition(float t)
    {
        Vector2 position = (Vector2)shotPoint.position + (direction.normalized * launchForce * t) + 0.5f * Physics2D.gravity * (t * t);
        return position;
    }
    // //Attempt at switching the visual of a sling when he turns left.
    // void Swap()
    // {
    //     // changeScale = firstChild.transform.localScale;
    //     // changeScale.x *=-1;
    //     // firstChild.transform.localScale = changeScale;
    //     // isLeft = !isLeft;
    // }
}
