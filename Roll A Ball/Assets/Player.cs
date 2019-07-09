using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello world!");
    }

    // Update is called once per frame
    void Update()
    {
        float Horizontal = Input.GetAxis("Horizontal");
        Debug.Log("Horizontal = " + Horizontal.ToString());
        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("Booster");
        }
    }
}