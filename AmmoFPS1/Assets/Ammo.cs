using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("ammo " + name + " other " + other.name);

        if (other.tag=="Player")
        {
            GameManager.Instance.collectammo();
            Destroy(gameObject.transform.parent.gameObject);
        }

    }
}
