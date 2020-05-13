using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject Player;
    public Vector3 PlayerOffset;

    private Vector3 _offset;

    void Start()
    {
        _offset = transform.position - Player.transform.position;
    }

    void LateUpdate()
    {
        if (Player != null)
        {
            transform.position = Player.transform.position + _offset + PlayerOffset;
        }
    }
}
