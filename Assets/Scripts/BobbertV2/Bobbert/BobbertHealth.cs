using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BobbertHealth : MonoBehaviour
{
    public int maxHealth = 6;
    public int health;
    
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Other enemies call this function
    // Also will be used by scissors !
    public void UpdateHealth(int mod)
    {
        health += mod;

        if (health > maxHealth)
        {
            health = maxHealth;
        } else if (health <= 0)
        {
            health = 0;
            PlayerDied();
        }
    }

    private void PlayerDied()
    {
        LevelManager.instance.GameOver();
        gameObject.SetActive(false);
    }
}
