﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingEntity : MonoBehaviour, IDamagable
{
    public float StartingHealth;

    protected float Health;
    protected bool Dead;

    public event System.Action OnDeath;

    public int GetHealth()
    {
        return (int)Health;
    }

    protected virtual void Start()
    {
        Health = StartingHealth;
    }

    public void TakeHit(float damage, RaycastHit hit)
    {
        TakeDamage(damage);
    }

    public void TakeDamage(float damage)
    {
        Health -= damage;
        if (Health <= 0 && !Dead)
        {
            Die();
        }
    }

    protected void Die()
    {
        Dead = true;
        if(OnDeath != null)
        {
            OnDeath();
        }
        GameObject.Destroy(gameObject);
    }
}
