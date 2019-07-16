using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour
{
    private Rigidbody mRB;
    public float Speed;
    // Start is called before the first frame update
    void Start()
    {
        mRB = GetComponent<Rigidbody>();
        mRB.velocity = Vector3.back * Speed;
    }

    public void SetSpeed(float inputSpeed)
    {
        Speed = inputSpeed;
        mRB.velocity = Vector3.back * Speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bumper"))
        {
            transform.position = transform.position + (Vector3.forward * 40.96f);
        }
    }
}
