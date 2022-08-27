using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 4f;
    public GameObject dieEffect;

    public static int EnemyIsAlive = 0;

    private void Start()
    {
        EnemyIsAlive++;
    }
    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (collisionInfo.relativeVelocity.magnitude > health)
        {
            Die();
        }
    }
    void Die()
    {
        Instantiate(dieEffect, transform.position, Quaternion.identity);
        EnemyIsAlive--;
        if (EnemyIsAlive <= 0)
        {
            Debug.Log("Win");
        }
        Destroy(gameObject);
    }
}
