using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum eEffectType
{
    AsteroidExp,
    EnemyExp,
    PlayerExp
}

public class EffectPool : MonoBehaviour
{
    public Timer[] PrefabArr;
    private List<Timer>[] PoolArr;

    // Start is called before the first frame update
    void Start()
    {
        PoolArr = new List<Timer>[PrefabArr.Length];
        for (int i = 0; i < PoolArr.Length; i++)
        {
            PoolArr[i] = new List<Timer>();
        }
    }

    public Timer GetFromPool(int id)
    {
        for (int i = 0; i < PoolArr[id].Count; i++)
        {
            if (!PoolArr[id][i].gameObject.activeInHierarchy)
            {
                PoolArr[id][i].gameObject.SetActive(true);
                return PoolArr[id][i];
            }
        }
        Timer newObj = Instantiate(PrefabArr[id]);
        PoolArr[id].Add(newObj);
        return newObj;
    }
}
