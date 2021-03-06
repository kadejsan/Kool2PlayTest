﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(GunController))]
public class Player : LivingEntity
{
    public float MoveSpeed = 5.0f;

    private Camera _viewCamera;
    private PlayerController _controller;
    private GunController _gunController;

    public GunController GetGunController()
    {
        return _gunController;
    }

    protected override void Start()
    {
        base.Start();

        _controller = GetComponent<PlayerController>();
        _gunController = GetComponent<GunController>();
        _viewCamera = Camera.main;
    }

    void Update()
    {
        // Movement input
        Vector3 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Vector3 moveVelocity = moveInput.normalized * MoveSpeed;
        _controller.Move(moveVelocity);

        // Look at mouse cursor input
        Ray ray = _viewCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayDistance;

        if(groundPlane.Raycast(ray, out rayDistance))
        {
            Vector3 point = ray.GetPoint(rayDistance);
            _controller.LookAt(point);
        }

        // Weapon input
        if(Input.GetMouseButton(0))
        {
            _gunController.Shoot();
        }

        // Weapon equip
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            _gunController.EquipGun(0);
        }
        else if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            _gunController.EquipGun(1);
        }
    }
}
