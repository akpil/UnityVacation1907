using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject mPlayerObj;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = mPlayerObj.transform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = mPlayerObj.transform.position - offset;
    }
}
