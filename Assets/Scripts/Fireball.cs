using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float Speed;
    public float LifeTime;
    public float Damage = 10;
    private void Start()
    {
        Invoke("FireballDestroy", LifeTime);
    }

    void FixedUpdate()
    {
        MoveFixedUpdate();
    }

    private void OnCollisionEnter(Collision collision)
    {
        DamageEnemy(collision);
        FireballDestroy();
    }

    private void DamageEnemy(Collision collision)
    {
        var enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
        if (enemyHealth != null)
        {
            enemyHealth.DealDamage(Damage);
        }
    }

    private void FireballDestroy()
    {
        Destroy(gameObject);
    }

    private void MoveFixedUpdate()
    {
        transform.position += transform.forward * Speed * Time.fixedDeltaTime;
    }
}
