using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public SoundController soundControl;
    public UIController UIControl;

    public BGScroller[] BGArr;
    public float BGScrollSpeed;

    public Player player;

    private bool mbGameOver;

    public EnemyPool enemyPool;
    public AsteroidPool asteroidPool;
    public float SpawnZPos;
    public float SpawnXMin;
    public float SpawnXMax;
    public int AstSpawnCount;
    public int EnemySpawnCount;
    public int Score;
    private Coroutine hazardRoutine;
    // Start is called before the first frame update
    void Start()
    {
        //hazardRoutine = StartCoroutine(SpawnHazard());

        for (int i = 0; i < BGArr.Length; i++)
        {
            BGArr[i].SetSpeed(BGScrollSpeed);
        }
        mbGameOver = false;
        UIControl.ShowStatus("");
        Score = 0;
        UIControl.ShowScore(Score);
    }

    public SoundController GetSoundController()
    {
        return soundControl;
    }

    public void AddScore(int amount)
    {
        Score = Score + amount;
        UIControl.ShowScore(Score);
    }

    public void GameOver()
    {
        UIControl.ShowStatus("Game Over..");
        for (int i = 0; i < BGArr.Length; i++)
        {
            BGArr[i].SetSpeed(0);
        }
        StopCoroutine(hazardRoutine);
        mbGameOver = true;
    }

    public void RestartGame()
    {
        UIControl.ShowStatus("");
        Score = 0;
        UIControl.ShowScore(Score);
        for (int i = 0; i < BGArr.Length; i++)
        {
            BGArr[i].SetSpeed(BGScrollSpeed);
        }
        hazardRoutine = StartCoroutine(SpawnHazard());
        player.transform.position = Vector3.zero;
        player.gameObject.SetActive(true);
        mbGameOver = false;
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
        if (Input.GetKeyDown(KeyCode.R) && mbGameOver)
        {
            RestartGame();
        }
    }
}
