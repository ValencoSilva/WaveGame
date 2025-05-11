using System.Collections;
using UnityEngine;

public class SpawnerSystem : MonoBehaviour
{
    [SerializeField] GameObject Enemys;
    [SerializeField] int enemyRate;
    [SerializeField] int enemyTotal;



    int enemyCount;


 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyCount = 0;
        StartCoroutine(EnemyCd(enemyRate));
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void Spawner()
    {
        if (enemyCount < enemyTotal)
        {

            Vector3 randomPos = new Vector3(Random.Range(109, -9), 1, Random.Range(9, -106));
            Instantiate(Enemys, randomPos, Quaternion.identity);
            enemyCount++;
        }
       
    }

    IEnumerator EnemyCd(int enemyRate)
    {
        while (true)
        {
            Spawner();
            yield return new WaitForSeconds(enemyRate);
        }
       
    }
}
