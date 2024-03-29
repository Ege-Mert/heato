using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 40;

    public Rigidbody2D rb;

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null){
            enemy.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
