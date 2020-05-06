﻿using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : LivingEntity
{
    private NavMeshAgent _pathFinder;
    private Transform _target;

    protected override void Start()
    {
        base.Start();

        _pathFinder = GetComponent<NavMeshAgent>();
        _target = GameObject.FindGameObjectWithTag("Player").transform;

        StartCoroutine(UpdatePath());
    }

    void Update()
    {
    }

    IEnumerator UpdatePath()
    {
        float refreshRate = 0.15f;
        while(_target != null && !Dead)
        {
            Vector3 targetPosition = new Vector3(_target.position.x, 0, _target.position.z);
            _pathFinder.SetDestination(targetPosition);
            yield return new WaitForSeconds(refreshRate);
        }
    }
}
