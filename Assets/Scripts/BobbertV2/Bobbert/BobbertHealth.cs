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
    public void TakeDamage(int dmg)
    {
        health -= dmg;
        if(health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
