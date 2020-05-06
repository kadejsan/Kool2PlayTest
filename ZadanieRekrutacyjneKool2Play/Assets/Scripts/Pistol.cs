using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Gun
{
    private float _nextShotTime;

    public override void Shoot()
    {
        if (Time.time > _nextShotTime)
        {
            _nextShotTime = Time.time + MilisecondsBetweenShots / 1000.0f;
            Projectile newProjectile = Instantiate(Projectile, Muzzle.position, Muzzle.rotation) as Projectile;
            newProjectile.SetSpeed(MuzzleVelocity);
        }
    }
}
