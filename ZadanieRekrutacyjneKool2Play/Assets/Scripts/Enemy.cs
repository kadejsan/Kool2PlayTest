using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : LivingEntity
{
    public enum State { Idle, Chasing, Attacking };
    private State _currentState;

    private NavMeshAgent _pathFinder;
    private Transform _target;
    private LivingEntity _targetEntity;

    private float _attackDistanceThreshold = 0.5f;
    private float _timeBetweenAttacks = 1.0f;
    private float _nextAttackTime;
    private float _enemyCollisionRadius;
    private float _targetCollisionRadius;

    public float Damage = 1;
    private bool _hasTarget;

    protected override void Start()
    {
        base.Start();

        _pathFinder = GetComponent<NavMeshAgent>();

        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            _hasTarget = true;
            _currentState = State.Chasing;
            _target = GameObject.FindGameObjectWithTag("Player").transform;
            _targetEntity = _target.GetComponent<LivingEntity>();
            _targetEntity.OnDeath += OnTargetDeath;

            _enemyCollisionRadius = GetComponent<CapsuleCollider>().radius;
            _targetCollisionRadius = _target.GetComponent<CapsuleCollider>().radius;

            StartCoroutine(UpdatePath());
        }
    }

    void OnTargetDeath()
    {
        _hasTarget = false;
        _currentState = State.Idle;
    }

    void Update()
    {
        if (_hasTarget)
        {
            if (Time.time > _nextAttackTime)
            {
                float sqrDstToTarget = (_target.position - transform.position).sqrMagnitude;
                float attackDistance = _attackDistanceThreshold + _enemyCollisionRadius + _targetCollisionRadius;
                if (sqrDstToTarget < attackDistance * attackDistance)
                {
                    _nextAttackTime = Time.time + _timeBetweenAttacks;
                    StartCoroutine(Attack());
                }
            }
        }
    }

    IEnumerator Attack()
    {
        _currentState = State.Attacking;
        _pathFinder.enabled = false;

        Vector3 originalPosition = transform.position;
        Vector3 dirToTarget = (_target.position - transform.position).normalized;
        Vector3 attackPosition = _target.position - dirToTarget * (_enemyCollisionRadius + _targetCollisionRadius);

        float attackSpeed = 3.0f;
        float percent = 0.0f;

        bool hasAppliedDamage = false;
        
        while(percent <= 1)
        {
            if(percent >= 0.5f && !hasAppliedDamage)
            {
                hasAppliedDamage = true;
                _targetEntity.TakeDamage(Damage);
            }

            percent += Time.deltaTime * attackSpeed;
            float interpolation = (-percent * percent + percent) * 4.0f;
            transform.position = Vector3.Lerp(originalPosition, attackPosition, interpolation);

            yield return null;
        }

        _currentState = State.Chasing;
        _pathFinder.enabled = true;
    }

    IEnumerator UpdatePath()
    {
        float refreshRate = 0.15f;
        while(_hasTarget && !Dead)
        {
            if (_currentState == State.Chasing)
            {
                Vector3 dirToTarget = (_target.position - transform.position).normalized;
                Vector3 targetPosition = _target.position - dirToTarget * (_enemyCollisionRadius + _targetCollisionRadius + _attackDistanceThreshold / 2.0f);
                _pathFinder.SetDestination(targetPosition);
            }
            yield return new WaitForSeconds(refreshRate);
        }
    }
}
