using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public LayerMask CollisionMask;
    public float Speed = 10;
    public float Damage = 1;
    public float SecondsAlive = 1.0f;

    private float _skinWidth = 0.1f;

    private void Start()
    {
        Destroy(gameObject, SecondsAlive);

        Collider[] initialCollissions = Physics.OverlapSphere(transform.position, 0.1f, CollisionMask);
        if(initialCollissions.Length > 0)
        {
            OnHitObject(initialCollissions[0]);
        }
    }

    public void SetSpeed(float speed)
    {
        Speed = speed;
    }

    void Update()
    {
        float moveDistance = Speed * Time.deltaTime;
        CheckCollisions(moveDistance);
        transform.Translate(Vector3.forward * moveDistance);
    }

    void CheckCollisions(float moveDistance)
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, moveDistance + _skinWidth, CollisionMask, QueryTriggerInteraction.Collide))
        {
            OnHitObject(hit); 
        }
    }

    void OnHitObject(RaycastHit hit)
    {
        IDamagable damageableObject = hit.collider.GetComponent<IDamagable>();
        if(damageableObject != null)
        {
            damageableObject.TakeHit(Damage, hit);
        }
        GameObject.Destroy(gameObject);
    }

    void OnHitObject(Collider c)
    {
        IDamagable damageableObject = c.GetComponent<IDamagable>();
        if (damageableObject != null)
        {
            damageableObject.TakeDamage(Damage);
        }
        GameObject.Destroy(gameObject);
    }
}
