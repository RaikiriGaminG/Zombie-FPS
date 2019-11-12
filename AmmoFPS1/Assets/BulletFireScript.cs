using UnityEngine;
using System.Collections;

public class BulletFireScript : MonoBehaviour
{

    public Transform bulletprefab;
    // Use this for initialization
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")&&(GameManager.Instance.ammocount>0))
        {
            Instantiate(bulletprefab, transform.position, transform.rotation);
            GameManager.Instance.fire();
        }
    }
}
