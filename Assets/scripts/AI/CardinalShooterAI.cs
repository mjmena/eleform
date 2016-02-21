﻿using UnityEngine;
using System.Collections;

public class CardinalShooterAI : MonoBehaviour
{
    public GameObject projectile;
    public float projectile_speed;
    public float shoot_cooldown;
    private float last_shot; 

    void Update()
    {
        if (Time.time - last_shot > shoot_cooldown)
        {
            spawnProjectile(transform.up);
            spawnProjectile(-transform.up);
            spawnProjectile(-transform.right);
            spawnProjectile(transform.right);
            
            last_shot = Time.time;
        }
    }

    void spawnProjectile(Vector3 direction)
    {
        Vector3 bullet_position = transform.position + direction;
        Vector3 bullet_velocity = direction * projectile_speed;

        
        GameObject go = Instantiate(projectile, bullet_position, Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * 180 / Mathf.PI - 90)) as GameObject;
        
        go.name = "enemy_projectile";
        go.tag = gameObject.tag;
        go.GetComponent<Rigidbody2D>().velocity = bullet_velocity;
        go.GetComponent<DamageProjectileEffect>().damage = 10;
        go.GetComponent<DamageProjectileEffect>().SetLifetime(1);
    }
}