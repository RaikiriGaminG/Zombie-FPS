using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBehaviour : MonoBehaviour
{
    public GameObject Zombies;
    public GameObject EnemySpawner;
    public int XPos;
    public int ZPos;
    private int EnemyCount;

     void Start()
    {
        StartCoroutine(EnemySpawn());
    }
    IEnumerator EnemySpawn()
    {
        while (EnemyCount < 50)
        {
            XPos = Random.Range(1, 511);
            ZPos = Random.Range(1, 511);
            Instantiate(Zombies, new Vector3(XPos, 39.941f, ZPos), Quaternion.identity);
            yield return new WaitForSeconds(0.2f);
            EnemyCount += 1;
        }
    }
}
