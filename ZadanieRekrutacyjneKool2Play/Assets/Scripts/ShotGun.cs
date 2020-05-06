using System.Collections.Generic;
using UnityEngine;

public class ShotGun : Gun
{
    public int PelletCount;
    public float SpreadAngle;

    private List<Quaternion> _pellets;

    void Awake()
    {
        _pellets = new List<Quaternion>(PelletCount);
        for (int i = 0; i < PelletCount; ++i)
        {
            _pellets.Add(Quaternion.Euler(Vector3.zero));
        }
        OverrideDamage();
    }

    public override void Shoot()
    {
        if (Time.time > _nextShotTime)
        {
            _nextShotTime = Time.time + MilisecondsBetweenShots / 1000.0f;
            for(int i = 0; i < PelletCount; ++i)
            {
                _pellets[i] = Random.rotation;
                Projectile newProjectile = Instantiate(Projectile, Muzzle.position, Muzzle.rotation) as Projectile;
                newProjectile.transform.rotation = Quaternion.RotateTowards(newProjectile.transform.rotation, _pellets[i], SpreadAngle);
                newProjectile.SetSpeed(MuzzleVelocity);
            }
        }
    }

    public override void OverrideDamage()
    {
        Projectile.Damage = ProjectileDamage;
    }
}
