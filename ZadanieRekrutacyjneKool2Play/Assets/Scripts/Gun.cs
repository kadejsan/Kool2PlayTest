using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform Muzzle;
    public Projectile Projectile;
    public float MilisecondsBetweenShots = 100;
    public float MuzzleVelocity = 35;

    private float _nextShotTime;

    public void Shoot()
    {
        if (Time.time > _nextShotTime)
        {
            _nextShotTime = Time.time + MilisecondsBetweenShots / 1000.0f;
            Projectile newProjectile = Instantiate(Projectile, Muzzle.position, Muzzle.rotation) as Projectile;
            newProjectile.SetSpeed(MuzzleVelocity);
        }
    }
}
