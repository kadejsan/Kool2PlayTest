using System.Collections.Generic;
using UnityEngine;

public class ShotGun : Gun
{
    public int PelletCount;
    public float SpreadAngle;
    public GameObject Pellet;

    private List<Quaternion> _pellets;

    void Awake()
    {
        _pellets = new List<Quaternion>(PelletCount);
        for (int i = 0; i < PelletCount; ++i)
        {
            _pellets.Add(Quaternion.Euler(Vector3.zero));
        }
    }

    private void Update()
    {

    }

    public override void Shoot()
    {
    }
}
