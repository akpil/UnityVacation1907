using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaugeBarPool : MonoBehaviour
{
    public GaugeBar Origin;
    public Transform OriginParents;
    private List<GaugeBar> Pool;

    // Start is called before the first frame update
    void Awake()
    {
        Pool = new List<GaugeBar>();
    }

    public GaugeBar GetFromPool()
    {
        for (int i = 0; i < Pool.Count; i++)
        {
            if (!Pool[i].gameObject.activeInHierarchy)
            {
                Pool[i].gameObject.SetActive(true);
                return Pool[i];
            }
        }
        GaugeBar newObj = Instantiate(Origin, OriginParents);
        //GaugeBar newObj = Instantiate(Origin);
        //newObj.transform.SetParent(OriginParents);
        //newObj.transform.localScale = new Vector3(1, 1, 1);
        //newObj.transform.position = Vector3.zero;
        Pool.Add(newObj);
        return newObj;
    }
}
