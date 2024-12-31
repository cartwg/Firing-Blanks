using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxScript : MonoBehaviour
{
    public Slider HealthBar;
    public float health = 5;
    public HealthBar healthBar;
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "bullet")
         {
             health -= 1;
            healthBar.SetHealth(health);
         }
        HealthBar.gameObject.SetActive(true);
    }
}
