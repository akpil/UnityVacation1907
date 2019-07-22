using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour
{
    private Rigidbody mRB;
    // Start is called before the first frame update
    void Awake()
    {
        mRB = GetComponent<Rigidbody>();
    }

    public void SetSpeed(float inputSpeed)
    {
        mRB.velocity = Vector3.back * inputSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bumper"))
        {
            transform.position = transform.position + (Vector3.forward * 40.96f);
        }
    }
}
