using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidPool : MonoBehaviour
{
    public AsteroidMovement[] PrefabArr;
    private List<AsteroidMovement>[] PoolArr;

    // Start is called before the first frame update
    void Start()
    {
        PoolArr = new List<AsteroidMovement>[PrefabArr.Length];
        for (int i = 0; i < PoolArr.Length; i++)
        {
            PoolArr[i] = new List<AsteroidMovement>();
        }
    }

    public AsteroidMovement GetFromPool(int id)
    {
        for (int i = 0; i < PoolArr[id].Count; i++)
        {
            if (!PoolArr[id][i].gameObject.activeInHierarchy)
            {
                PoolArr[id][i].gameObject.SetActive(true);
                return PoolArr[id][i];
            }
        }
        AsteroidMovement newObj = Instantiate(PrefabArr[id]);
        PoolArr[id].Add(newObj);
        return newObj;
    }
}
