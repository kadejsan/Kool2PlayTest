using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    private Vector3 _velocity;
    private Rigidbody _myRigidBody;

    void Start()
    {
        _myRigidBody = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 velocity)
    {
        _velocity = velocity;
    }

    public void LookAt(Vector3 lookAtPoint)
    {
        Vector3 lookAtHeightCorrected = new Vector3(lookAtPoint.x, transform.position.y, lookAtPoint.z);
        transform.LookAt(lookAtHeightCorrected);
    }

    void FixedUpdate()
    {
        _myRigidBody.MovePosition(_myRigidBody.position + _velocity * Time.fixedDeltaTime);
    }

}
