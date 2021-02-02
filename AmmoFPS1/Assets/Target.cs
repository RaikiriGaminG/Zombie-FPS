using UnityEngine;
 
public class Target : MonoBehaviour
{
    public float health = 200f;
    public int AddScoreAmount;
    public GameObject AmmoBox;
    private int SpawnPos;
    public Animator Anim;
    //add this part
    [SerializeField]
    private Score score;

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
            score.AddScore(AddScoreAmount);
           //AddScoreAmount = GetComponent<Score>().CurrentScore + 10;
        }
    }
    void Die()
    {
        Anim.SetBool("Death", true);
        AmmoBoxSpawn();
        Destroy(gameObject);
    }
 
    public void AmmoBoxSpawn()
    {
        Instantiate(AmmoBox, new Vector3 (transform.position.x, 40.26f, transform.position.z), Quaternion.identity);
    }


}