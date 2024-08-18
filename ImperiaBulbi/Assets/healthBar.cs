using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour
{
    public Slider healthSlider;
    public Slider easeHealthSlider;
    public float maxHealth = 100f;
    public float health;
    private float LerpSpeed = 0.03f;
    void Start()
    {
        health = maxHealth;
    }
    void Update()
    {
        if(healthSlider.value != health)
        {
            healthSlider.value = health;  
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(10);
        }

        if(healthSlider.value != easeHealthSlider.value)
        {
            easeHealthSlider.value = Mathf.Lerp(easeHealthSlider.value, health, LerpSpeed);
        }
    }

    void TakeDamage(float damage)
    {
        health -= damage;
    }
}
