using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltPool : MonoBehaviour
{
    public Bolt Prefab;
    private List<Bolt> Pool;

    // Start is called before the first frame update
    void Start()
    {
        Pool = new List<Bolt>();
    }

    public Bolt GetFromPool()
    {
        for (int i = 0; i < Pool.Count; i++)
        {
            if (!Pool[i].gameObject.activeInHierarchy)
            {
                Pool[i].gameObject.SetActive(true);
                return Pool[i];
            }
        }
    }
}
