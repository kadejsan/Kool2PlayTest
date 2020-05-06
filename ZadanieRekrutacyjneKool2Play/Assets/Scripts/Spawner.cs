using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Enemy Enemy;
    public float TimeBetweenSpawns;

    private float _nextSpawnTime;

    private int _enemiesKilled = 0;

    void Update()
    {
        if(Time.time > _nextSpawnTime)
        {
            _nextSpawnTime = Time.time + TimeBetweenSpawns;

            float x = Random.Range(-50.0f, 50.0f);
            float z = Random.Range(-50.0f, 50.0f);
            Enemy spawnedEnemy = Instantiate(Enemy, new Vector3(x, 0, z), Quaternion.identity) as Enemy;
            spawnedEnemy.OnDeath += OnEnemyDeath;
        }
    }

    void OnEnemyDeath()
    {
        _enemiesKilled++;
    }

    public int GetEnemiesKilled()
    {
        return _enemiesKilled;
    }
}
