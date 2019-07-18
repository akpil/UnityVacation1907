using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    public EnemyController Prefab;
    private List<EnemyController> Pool;
    public BoltPool EnemyBoltPool;

    // Start is called before the first frame update
    void Start()
    {
        Pool = new List<EnemyController>();
    }

    public EnemyController GetFromPool()
    {
        for (int i = 0; i < Pool.Count; i++)
        {
            if (!Pool[i].gameObject.activeInHierarchy)
            {
                Pool[i].gameObject.SetActive(true);
                return Pool[i];
            }
        }
        EnemyController newObj = Instantiate(Prefab);
        newObj.SetUP(EnemyBoltPool);
        Pool.Add(newObj);
        return newObj;
    }
}
