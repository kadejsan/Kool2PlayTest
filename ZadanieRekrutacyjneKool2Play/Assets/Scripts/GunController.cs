using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public Transform WeaponHold;
    public Gun[] Guns;

    private Gun _equippedGun;

    private void Start()
    {
        if(Guns[0] != null)
        {
            EquipGun(Guns[0]);
        }
    }

    public void EquipGun(Gun gunToEquip)
    {
        if (_equippedGun != null)
            Destroy(_equippedGun.gameObject);

        _equippedGun = Instantiate(gunToEquip, WeaponHold.position, WeaponHold.rotation) as Gun;
        _equippedGun.transform.parent = WeaponHold;
    }

    public void Shoot()
    {
        if(_equippedGun != null)
        {
            _equippedGun.Shoot();
        }
    }
}
