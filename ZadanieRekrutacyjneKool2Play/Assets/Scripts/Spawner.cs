using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Enemy Enemy;
    public float TimeBetweenSpawns;

    private float _nextSpawnTime;

    void Start()
    {
    }

    void Update()
    {
        if(Time.time > _nextSpawnTime)
        {
            _nextSpawnTime = Time.time + TimeBetweenSpawns;

            Enemy spawnedEnemy = Instantiate(Enemy, Vector3.zero, Quaternion.identity) as Enemy;
        }
    }
}
