using System.Collections;
using Unity.Collections;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public float Damage = 10f;
    public float Range = 100f;
    public float ImpactForce = 40f;
    public float FireRate = 15f;
    public int AmmoInMagazine = 30;
    private int MaximumAmmo = 180;
    public Camera FpsCam;
    public ParticleSystem MuzzleFlash;
    public GameObject ImpactEffect;
    public int MaxAmmo = 180;
    [SerializeField] private float NextTimeToFire = 0f;
    public int CurrentAmmo;
    public float ReloadTime = 2f;
    private bool IsReloading = false;
    public Animator Animator;
    void OnEnable()
    {
        IsReloading = false;
        Animator.SetBool("Reloading", false);
    }

    void Start()
    {
        CurrentAmmo = AmmoInMagazine;
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
        if (Input.GetKeyDown(KeyCode.R) && CurrentAmmo < MaxAmmo)

        {

            StartCoroutine(Reload());

        }
    }
    void Shoot()
    {
        MuzzleFlash.Play();
        CurrentAmmo--;
        RaycastHit Hit;
        if (Physics.Raycast(FpsCam.transform.position, FpsCam.transform.forward, out Hit, Range))
        {
            Target Target = Hit.transform.GetComponent<Target>();
            if (Hit.transform.tag == "Enemy")
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
        var ammo = Mathf.Min(AmmoInMagazine, MaxAmmo);
        MaxAmmo -= ammo;
        CurrentAmmo = ammo;
        IsReloading = false;
    }
    public void ReplenishAmmo()
    {
        MaxAmmo = MaximumAmmo;
        CurrentAmmo = AmmoInMagazine;
    }
}