using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int healthMax = 100;
    public int health;

    public HealthBar healthBar;
    public GameManagerScpirt gameManager;

    private bool isDead;

    void Start()
    {
        health = healthMax;
        healthBar.SetMaxHealth(healthMax);
    }

    public void TakeDamage(int damage){
        health -= damage;
        healthBar.SetHealth(health);
        if(health <= 0 && !isDead){
            isDead = true;
            gameManager.gameOver();
            Destroy(gameObject);
        }
    }
}
