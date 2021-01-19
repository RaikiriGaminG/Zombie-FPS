using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{
    public int CurrentWeapon = 0;
    // Start is called before the first frame update
    void Start()
    {
        SelectWeapon();

    }

    // Update is called once per frame
    void Update()
    {
        int PreviousWeapon = CurrentWeapon;

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (CurrentWeapon >= transform.childCount - 1)
            {
                CurrentWeapon = 0;
            }
            else
            {
                CurrentWeapon++;
            }

        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (CurrentWeapon <= 0)
            {
                CurrentWeapon = transform.childCount - 1;
            }
            else
            {
                CurrentWeapon--;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            CurrentWeapon = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2)
        {
            CurrentWeapon = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 3)
        {
            CurrentWeapon = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) && transform.childCount >= 4)
        {
            CurrentWeapon = 3;
        }
        if (PreviousWeapon != CurrentWeapon)
        {
            SelectWeapon();
        }
    }
    void SelectWeapon()
    {
        int i = 0;
        foreach (Transform Weapon in transform)
        {
            if (i == CurrentWeapon)
            {
                Weapon.gameObject.SetActive(true);
            }
            else
            {
                Weapon.gameObject.SetActive(false);
            }
            i++;
        }

    }
}
