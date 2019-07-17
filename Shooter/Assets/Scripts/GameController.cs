using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public AsteroidPool asteroidPool;
    public float SpawnZPos;
    public float SpawnXMin;
    public float SpawnXMax;
    public int AstSpawnCount;
    public float SpawnPeriod;
    private float currentSpawnPeriod;

    // Start is called before the first frame update
    void Start()
    {
        currentSpawnPeriod = SpawnPeriod;
    }

    // Update is called once per frame
    void Update()
    {
        currentSpawnPeriod = currentSpawnPeriod - Time.deltaTime;
        if (currentSpawnPeriod <= 0)
        {
            for (int i = 0; i < AstSpawnCount; i++)
            {
                AsteroidMovement ast = asteroidPool.GetFromPool(Random.Range(0,3));
                ast.transform.position = new Vector3(Random.Range(SpawnXMin, SpawnXMax),
                                                     0,
                                                     SpawnZPos);
            }
            currentSpawnPeriod = SpawnPeriod;
        }
    }
}
