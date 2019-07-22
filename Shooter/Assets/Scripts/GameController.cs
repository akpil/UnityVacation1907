using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public SoundController soundControl;
    public EnemyPool enemyPool;
    public AsteroidPool asteroidPool;
    public float SpawnZPos;
    public float SpawnXMin;
    public float SpawnXMax;
    public int AstSpawnCount;
    public int EnemySpawnCount;
    public int Score;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnHazard());
    }

    public SoundController GetSoundController()
    {
        return soundControl;
    }

    public void AddScore(int amount)
    {
        Score = Score + amount;
    }

    private IEnumerator SpawnHazard()
    {
        int currentAstCount = AstSpawnCount;
        int currentEnemyCount = EnemySpawnCount;
        yield return new WaitForSeconds(3);
        while (true)
        {
            if (currentAstCount > 0 && currentEnemyCount > 0)
            {
                float randVal = Random.Range(0, 100f);
                if (randVal < 30) // enemy spawn
                {
                    EnemyController enemy = enemyPool.GetFromPool();
                    enemy.transform.position = new Vector3(Random.Range(SpawnXMin, SpawnXMax),
                                                         0,
                                                         SpawnZPos);
                    yield return new WaitForSeconds(.4f);
                    currentEnemyCount--;
                }
                else // asteroid spawn
                {
                    AsteroidMovement ast = asteroidPool.GetFromPool(Random.Range(0, 3));
                    ast.transform.position = new Vector3(Random.Range(SpawnXMin, SpawnXMax),
                                                         0,
                                                         SpawnZPos);
                    yield return new WaitForSeconds(.4f);
                    currentAstCount--;
                }
            }
            else if (currentAstCount > 0)
            {
                for (int i = 0; i < currentAstCount; i++)
                {
                    AsteroidMovement ast = asteroidPool.GetFromPool(Random.Range(0, 3));
                    ast.transform.position = new Vector3(Random.Range(SpawnXMin, SpawnXMax),
                                                         0,
                                                         SpawnZPos);
                    yield return new WaitForSeconds(.4f);
                }
                currentAstCount = 0;
            }
            else if (currentEnemyCount > 0)
            {
                for (int i = 0; i < currentEnemyCount; i++)
                {
                    EnemyController enemy = enemyPool.GetFromPool();
                    enemy.transform.position = new Vector3(Random.Range(SpawnXMin, SpawnXMax),
                                                         0,
                                                         SpawnZPos);
                    yield return new WaitForSeconds(.4f);
                }
                currentEnemyCount = 0;
            }
            else
            {
                currentAstCount = AstSpawnCount;
                currentEnemyCount = EnemySpawnCount;
                yield return new WaitForSeconds(3);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
