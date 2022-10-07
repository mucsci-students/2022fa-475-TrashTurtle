using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sling : MonoBehaviour
{ 
    Transform firstChild;
    Vector3 changeScale;
    Vector2 direction;
    GameObject[] points;                // Array of points to display prefab crosshair.
    
    public Transform shotPoint;         // The transform that shells appear from on Bobbert
    public GameObject shot;             // SlingAmmo prefab
    public GameObject player;           // Bobbert
    public GameObject point;            // Where the shot will land
    public float spaceBetweenPoints;    // Distance between points along the trajectory
    public float launchForce;           // speed of projectile
    public bool showTrajectory;         // Boolean to control them display of crosshair
    public bool shooty;
    public int numberOfPoints;          // Amount of of points to display in the array.
    public bool isPaused;
    public PauseMenu pauseMenu;

    // Generates the prefab of opaque turtle shell a bunch of times.
    private void Start() {
        showTrajectory = false;
        isPaused = false;
       
        points = new GameObject[numberOfPoints];

        for (int i = 0; i < numberOfPoints; i++)
        {
            points[i] = Instantiate(point, -500* shotPoint.position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update(){
        Vector2 slingPosition = transform.position;
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        showTrajectory = Input.GetMouseButton(0);

        isPaused = pauseMenu.GameIsPaused;

        if (!isPaused){
        // If left click is held down
        if(showTrajectory)
        {
            // Display crosshair
            for(int i = 0; i < numberOfPoints; i++)
            {
                points[i].transform.position = PointPosition(i * spaceBetweenPoints);
            }
            // if bobbert is facing right
            if(player.transform.localScale.x == 1) 
            {
                // Check the (x,y) coordinates of the mouse are to the right of bobbert.
                if(mousePos.x > player.transform.position.x && mousePos.y > player.transform.position.y)
                {   
                    // Aim the shot at the cursor location
                    direction = mousePos - slingPosition;
                    transform.right = direction;

                    // If left click is released
                    if(Input.GetMouseButtonUp(0))
                    {
                        Shoot();
                        // Hide crosshair.
                        for(int i = 0; i < numberOfPoints; i++)
                        {
                            points[i].transform.position = HideTrajectory(i * 0);
                        }
                    }
                }
            }

            // If Bobbert is facing left
            if(player.transform.localScale.x == -1)
            {        
                // Check the (x,y) coordinates of the mouse are to the left of bobbert.
                if(mousePos.x < player.transform.position.x && mousePos.y > player.transform.position.y)
                {
                    // Aim the shot at the cursor location
                    direction = mousePos - slingPosition;
                    transform.right = direction;
                    
                    // If left click is released
                    if(Input.GetMouseButtonUp(0))
                    {
                        Shoot();
                        // Hide crosshair.
                        for(int i = 0; i < numberOfPoints; i++)
                        {
                            points[i].transform.position = HideTrajectory(i * 0);
                        }
                    }
                }
            }
        }
        }

        // Sanity check, fire and remove crosshair
        if(Input.GetMouseButtonUp(0))
        {
            Shoot();
            // Hide crosshair.
            for(int i = 0; i < numberOfPoints; i++)
            {
                points[i].transform.position = HideTrajectory(i * 0);
            }
        }
    }

    // Pew pew time.
    void Shoot() {
        if(!isPaused){
            showTrajectory = false;   
            GameObject newShot = Instantiate(shot, shotPoint.position, shotPoint.rotation);
            newShot.GetComponent<Rigidbody2D>().velocity = transform.right * launchForce;
        }
    }

    // Where to place the points showing the trajectory.
    Vector2 PointPosition(float t)
    {
        Vector2 position = (Vector2)shotPoint.position + (direction.normalized * launchForce * t) + 0.5f * Physics2D.gravity * (t * t);
        return position;
    }

    // Hides the shell after every shot.
    Vector2 HideTrajectory(float t)
    {
        t=0;
        Vector2 position = (Vector2)shotPoint.position* -500 + (0*direction.normalized * launchForce * t)*0f * Physics2D.gravity * (t * 0);
        return position;
    }

}
