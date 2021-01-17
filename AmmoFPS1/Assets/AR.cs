
using UnityEngine;

public class AR : MonoBehaviour
{

    public float Damage = 10f;
    public float Range = 100f;
    public float ImpactForce = 40f;
    public float FireRate = 15f;
    public Camera FpsCam;
    public ParticleSystem MuzzleFlash;
    public GameObject ImpactEffect;
    [SerializeField] private float NextTimeToFire = 0f;
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= NextTimeToFire)
        {
            NextTimeToFire = Time.time + 1f / FireRate;
            Shoot();
        }
    }
    void Shoot()
    {
        MuzzleFlash.Play();
        RaycastHit Hit;
        Physics.Raycast(FpsCam.transform.position, FpsCam.transform.forward, out Hit, Range);
        Target Target = Hit.transform.GetComponent<Target>();
        if (Target != null)
        {
            Target.TakeDamage(Damage);
        }
        if (Hit.rigidbody != null)
        {
            Hit.rigidbody.AddForce(-Hit.normal * ImpactForce);
        }
        GameObject Impact = Instantiate(ImpactEffect, Hit.point, Quaternion.LookRotation(Hit.normal));
        Destroy(Impact, 2f);
    }
}
