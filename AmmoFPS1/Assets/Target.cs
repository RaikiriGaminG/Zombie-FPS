using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 20000f;
    public Animator Anim;

    public void Start()
    {
        Anim.GetComponent<Animator>();
    }
    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Anim.SetBool("Death", true);
        Destroy(gameObject);
    }

}
