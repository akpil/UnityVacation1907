using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    private Rigidbody mRB;
    public float Speed;
    private void Awake()
    {
        mRB = GetComponent<Rigidbody>();
        mRB.velocity = Vector3.back * Speed;
    }
    private void OnEnable()
    {
        mRB.angularVelocity = Random.onUnitSphere * 3;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bolt") ||
            other.gameObject.CompareTag("Player"))
        {
            //점수 올리기
            //이펙트
            //사운드
            other.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
