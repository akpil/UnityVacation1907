using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody mRB;

    public Transform BoltPos;
    public GameObject BoltPrefab;

    public float Speed;
    public float Tilt;

    public float MinX;
    public float MaxX;
    public float MinZ;
    public float MaxZ;

    public float FireRate;
    private float currentFireTimer;


    // Start is called before the first frame update
    void Start()
    {
        currentFireTimer = 0;
        mRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 velocity = new Vector3(horizontal * Speed, 0, vertical * Speed);
        mRB.velocity = velocity;

        transform.rotation = Quaternion.Euler(0, 0, horizontal * -Tilt);

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, MinX, MaxX),
                                          0,
                                         Mathf.Clamp(transform.position.z, MinZ, MaxZ));

        currentFireTimer = currentFireTimer - Time.deltaTime;

        if (Input.GetButton("Fire1") && currentFireTimer <= 0)
        {
            GameObject newBolt = Instantiate(BoltPrefab);
            newBolt.transform.position = BoltPos.position;
            currentFireTimer = FireRate;
        }
    }
}
