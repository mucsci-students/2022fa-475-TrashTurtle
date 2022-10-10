using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    Color defaultColor;
    bool isHit = false;
    public float colorChangeTimer;
    public float Hitpoints;
    public float MaxHitpoints = 20;
    public healthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        Hitpoints = MaxHitpoints;
        // healthBar.SetHealth(Hitpoints, MaxHitpoints);
        spriteRenderer = GetComponentInParent<SpriteRenderer>();
        defaultColor = spriteRenderer.color;
    }

    public void TakeDamage(int damage){
        Hitpoints -= damage;

         if(!isHit)
        {
            isHit = true;
            // Idk how to explain Coroutine. But we can run a function as if it were in Update()
            StartCoroutine("Flash");
        }

        if(Hitpoints<= 0)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator Flash(){
        
        // Duration to flash Enemy.
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
        }
    }
}
