using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBox : MonoBehaviour
{
    public Transform Transform;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if (other.tag == "Player")
        {
            int i = 0;
            int currentweapon = other.GetComponentInChildren<WeaponSwitching>().CurrentWeapon;
            foreach (Transform Weapon in Transform)
            {
                if (i == currentweapon)
                {
                    Weapon.GetComponent<Gun>().ReplenishAmmo();
                }
                i++;
            }
        }   
    }
}
