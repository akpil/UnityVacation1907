using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public EnemyPool enemyPool;
    public AsteroidPool asteroidPool;
    public float SpawnZPos;
    public float SpawnXMin;
    public float SpawnXMax;
    public int AstSpawnCount;
    public int EnemySpawnCount;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnHazard());
    }

    private IEnumerator SpawnHazard()
    {
        while(true)
        {
            yield return new WaitForSeconds(3);
            for (int i = 0; i < AstSpawnCount; i++)
            {
                AsteroidMovement ast = asteroidPool.GetFromPool(Random.Range(0, 3));
                ast.transform.position = new Vector3(Random.Range(SpawnXMin, SpawnXMax),
                                                     0,
                                                     SpawnZPos);
                yield return new WaitForSeconds(.4f);
            }
            for (int i = 0; i < EnemySpawnCount; i++)
            {
                EnemyController enemy = enemyPool.GetFromPool();
                enemy.transform.position = new Vector3(Random.Range(SpawnXMin, SpawnXMax),
                                                     0,
                                                     SpawnZPos);
                yield return new WaitForSeconds(.4f);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
