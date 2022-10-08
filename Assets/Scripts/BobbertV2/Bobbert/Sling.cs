using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sling : MonoBehaviour
{           
    Vector2 direction;                  // Direction of shot.
    GameObject[] points;                // Array of points to display prefab crosshair.

    public PauseMenu pauseMenu;         // Detect if game is paused to prevent shooting.
    private bool isPaused;

    private Animator anim;              // Get direction Bobbert is facing and if shielding.
    private bool faceRight;             // Facing right?
    private bool isShielded;            // Shielding?

    public AudioSource audioSource;     // pew pew sound
    public Transform shotPoint;         // The transform that shells appear from on Bobbert.
    public GameObject shot;             // SlingAmmo prefab.
    public GameObject player;           // Bobbert.
    public GameObject point;            // Where the shot will land.

    public int numberOfPoints;          // Amount of of points to display in the array.
    public float spaceBetweenPoints;    // Distance between points along the trajectory.
    public float launchForce;           // Speed of projectile.
    public bool showTrajectory;         // Boolean to control the display of the crosshair.

    private bool canShootRight;         // Allowed to shoot right.
    private bool canShootLeft;          // Allowed to shoot left.
    public float shootCooldown = 0.5f;
    private float nextFireTime = 0f;
    public float spriteTimer;
    public bool didShoot;
    public Image cooldownImage;

    // Generates the prefab of opaque turtle shell a bunch of times.
    private void Start() {
        showTrajectory = false;
        isPaused = false;
        canShootLeft = false;
        canShootRight = false;
        didShoot = false;
        anim = player.GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

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
        isShielded = anim.GetBool("Shield");
        faceRight = anim.GetBool("FacingRight");
        spriteTimer = shootCooldown;
        
        // Bobbert facing right && mouse is in a 90 degree arc in front of him.
        if(faceRight && mousePos.x > player.transform.position.x)
            {canShootRight = true;}
        else
            {canShootRight = false;}

        //if(!faceRight && mousePos.x < player.transform.position.x && mousePos.y > player.transform.position.y)
        
        // Bobbert facing left and mouse is in a 90 degree arc in front of him.
        if(!faceRight && mousePos.x < player.transform.position.x)
            {canShootLeft = true;}
        else
            {canShootLeft = false;}

        if(canShootLeft || canShootRight)
        {
            // If left click is held down
            if(showTrajectory)
            {
                // Display crosshair
                for(int i = 0; i < numberOfPoints; i++)
                {
                    points[i].transform.position = PointPosition(i * spaceBetweenPoints);
                }
            }
            direction = mousePos - slingPosition;
            transform.right = direction;
        
            if(Time.time > nextFireTime)
            {
                // If left click is released
                if(Input.GetMouseButtonUp(0))
                {
                    Shoot();
                    nextFireTime = Time.time + shootCooldown;
                }

            }else{
                // Hide crosshair.
                for(int i = 0; i < numberOfPoints; i++)
                {
                    points[i].transform.position = HideTrajectory(i * 0);
                }  
            }
        }
        
        if(didShoot)
        {
            cooldownImage.fillAmount -= 1.0f / spriteTimer * Time.deltaTime;
            if(cooldownImage.fillAmount <= 0)
            {
                cooldownImage.fillAmount = 1.0f;
                didShoot = false;
            }
        }

        // If mouse moves out of shooting position
        if(Input.GetMouseButtonUp(0))
        {
            for(int i = 0; i < numberOfPoints; i++)
            {
                points[i].transform.position = HideTrajectory(i * 0);
            }  
        }

    }

    // Pew pew time.
    void Shoot() {
        if (!isPaused && !isShielded){
            // give me the good pew
            audioSource.PlayOneShot(audioSource.clip);
            GameObject newShot = Instantiate(shot, shotPoint.position, shotPoint.rotation);
            newShot.GetComponent<Rigidbody2D>().velocity = transform.right * launchForce;
            didShoot = true;
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