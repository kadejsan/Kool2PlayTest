﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float Speed = 10;

    public void SetSpeed(float speed)
    {
        Speed = speed;
    }

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * Speed);
    }
}
