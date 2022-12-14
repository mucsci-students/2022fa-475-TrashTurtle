using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BobbertHealth : MonoBehaviour
{
    public int maxHealth = 6;
    public int health;
    SpriteRenderer spriteRenderer;
    Color defaultColor;
    bool isHit = false;
    public float colorChangeTimer;
    public OwRandom ow;
    public HealthController hp;
    private bool shield;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();
        defaultColor = spriteRenderer.color;
    }

    // Other enemies call this function
    // Also will be used by scissors !
    public void UpdateHealth(int mod)
    {
        shield = Input.GetKey(KeyCode.S);

        // If Bobbert's health is going down:
        if(!shield && health + mod <= health)
        {
            if(!isHit)
            {
                isHit = true;
                ow.Hurt();
                // Idk how to explain Coroutine. But we can run a function as if it were in Update()
                StartCoroutine("Flash");
            }
        }
        
        if(!shield){
            health += mod;
            
            //hp.LifeBar(health);

            if (health > maxHealth)
            {
                health = maxHealth;
            } else if (health <= 0)
            {
                Debug.Log("Fkn be dead idiot");
                health = 0;
                PlayerDied();
            }
        }
    }
 
    private void PlayerDied()
    {
        LevelManager.instance.GameOver();
        gameObject.SetActive(false);
    }

    IEnumerator Flash(){
        
        // Duration to flash Bobbert.
        float duration = 0.5f;
        while(duration > 0)
        {
            //bAsE cAsE fOr nO iNFinIte L00p$
            duration -= Time.deltaTime;

            // It make it look flashy.
            float emission = Mathf.PingPong(2 * Time.time, 1f);
            
            // Color we're changing to
            Color baseColor = Color.red;
            // It make it look flashy 2.
            Color finalColor = baseColor * Mathf.LinearToGammaSpace(emission);
            
            // Set new color.
            spriteRenderer.color = finalColor;

            // Coroutine uses this yield return thing. I understand my code.
            yield return new WaitForSeconds(colorChangeTimer);
            // Change him back to his normal color
            spriteRenderer.color = defaultColor;
            isHit = false;
            // plese work
        }
    }
}
