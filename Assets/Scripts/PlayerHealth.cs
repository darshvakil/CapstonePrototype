using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 16;
    public int health;
    public Image healthBar;

    void Start()
    {
        health = maxHealth;
        UpdateHealthBar();
    }

    void Update()
    {
        UpdateHealthBar();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        health = Mathf.Clamp(health, 0, maxHealth); // Ensure health doesn't go below 0
        UpdateHealthBar();

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            healthBar.fillAmount = (float)health / maxHealth;
        }
    }
}
