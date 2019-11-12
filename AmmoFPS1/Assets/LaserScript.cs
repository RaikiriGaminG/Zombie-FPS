using UnityEngine;
using System.Collections;

public class LaserScript : MonoBehaviour
{
    LineRenderer line;
    GameManager gm;
    public GameObject explosionprefab;
    GameObject explosion;


    // Use this for initialization
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();

        line = gameObject.GetComponent<LineRenderer>();
        line.enabled = false;

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            StopCoroutine("FireLaser");
            StartCoroutine("FireLaser");
        }
    }

    IEnumerator FireLaser()
    {
        line.enabled = true;

        while (Input.GetButton("Fire1"))
        {
            line.GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0, Time.time);
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            line.SetPosition(0, ray.origin);
            if (Physics.Raycast(ray, out hit, 100))
            {
                line.SetPosition(1, hit.point);

                if (hit.rigidbody)
                {
                    hit.rigidbody.AddForceAtPosition(transform.forward * 50, hit.point);
                    gm.incscore(10);
                    explosion = Instantiate(explosionprefab, hit.point, this.transform.rotation) as GameObject;
                    Destroy(explosion, 5.0f);
                }

            }
            else
                line.SetPosition(1, ray.GetPoint(100));
            yield return null;
        }
        line.enabled = false;
    }
}