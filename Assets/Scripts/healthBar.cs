using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour
{   
    public Slider Slider;
    public Color low;
    public Color high;
    public Vector3 offset;
   
    public void SetHealth(float health, float maxHealth){

        Slider.gameObject.SetActive(health < maxHealth);

        Slider.value = health;
        Slider.maxValue = maxHealth;

        Slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(low, high, Slider.normalizedValue);
    }
    // Update is called once per frame
    void Update()
    {
        Slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + offset);
    }
}
