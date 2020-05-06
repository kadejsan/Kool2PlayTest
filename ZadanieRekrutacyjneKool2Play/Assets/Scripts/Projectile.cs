using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public LayerMask CollisionMask;
    public float Speed = 10;
    public float Damage = 1;
    public float SecondsAlive = 1.0f;

    private void Start()
    {
        Destroy(gameObject, SecondsAlive);
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

        if(Physics.Raycast(ray, out hit, moveDistance, CollisionMask, QueryTriggerInteraction.Collide))
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
}
