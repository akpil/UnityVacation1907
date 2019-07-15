using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolt : MonoBehaviour
{
    private Rigidbody mRB;
    public float Speed;
    // Start is called before the first frame update
    void Start()
    {
        mRB = GetComponent<Rigidbody>();
        mRB.velocity = transform.forward * Speed;
    }

    private void OnTriggerEnter(Collider other)
    {
    }
}
