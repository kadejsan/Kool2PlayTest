using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gun : MonoBehaviour
{
    public string GunName;
    
    public Transform Muzzle;
    public Projectile Projectile;
    public float MilisecondsBetweenShots = 100;
    public float MuzzleVelocity = 35;

    public abstract void Shoot();
}
