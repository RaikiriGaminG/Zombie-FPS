using System.Collections;
using Unity.Collections;
using UnityEngine;

public class Glock : MonoBehaviour
{
    public float Damage = 10f;
    public float Range = 30f;
    public float ImpactForce = 40f;
    public float FireRate = 5f;
    public Camera FpsCam;
    public ParticleSystem MuzzleFlash;
    public GameObject ImpactEffect;
    [SerializeField] private float NextTimeToFire = 0f;
    public int MaxAmmo = 75;
    [SerializeField] private int CurrentAmmo;
    public float ReloadTime = 1f;
    private bool IsReloading = false;
    public Animator Animator;
    void Start()
    {
        CurrentAmmo = 15;
    }
    void OnEnable()
    {
        IsReloading = false;
        Animator.SetBool("Reloading", false);
    }
    void Update()
    {
        if (CurrentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }
        if (Input.GetButton("Fire1") && Time.time >= NextTimeToFire)
        {
            NextTimeToFire = Time.time + 1f / FireRate;
            Shoot();
        }
    }
    void Shoot()
    {
        MuzzleFlash.Play();
        CurrentAmmo--;
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
    IEnumerator Reload()
    {
        if (IsReloading)
        {
            yield break;
        }
        IsReloading = true;
        Debug.Log("Reloading...");
        Animator.SetBool("Reloading", true);
        yield return new WaitForSeconds(ReloadTime - .25f);
        Animator.SetBool("Reloading", false);
        yield return new WaitForSeconds(.25f);
        var ammo = Mathf.Min(15, MaxAmmo);
        MaxAmmo -= ammo;
        CurrentAmmo = ammo;
        IsReloading = false;
    }
}
