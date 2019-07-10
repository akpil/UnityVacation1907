using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody mRB;
    public float Speed;
    // Start is called before the first frame update
    void Start()
    {
        mRB = GetComponent<Rigidbody>();
        Debug.Log("Hello world!");
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 power = new Vector3(horizontal * Speed, 0, vertical * Speed);

        //mRB.AddForce(power);
        mRB.velocity = power;

        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("Booster");
        }
    }
}