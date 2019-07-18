using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody mRB;
    public Transform BoltPos;
    public BoltPool pool;
    private Transform mPlayerTransform;

    void Awake()
    {
        mRB = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        StartCoroutine(AutoFire());
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        mPlayerTransform = player.transform;
        StartCoroutine(SideMovement());
    }

    private IEnumerator AutoFire()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(0.7f, 1.2f));
            Bolt bolt = pool.GetFromPool();
            bolt.transform.position = BoltPos.position;
        }
    }

    private IEnumerator SideMovement()
    {
        while (true)
        {
            float playerX = mPlayerTransform.position.x;
            Vector3 currentVel = mRB.velocity;
            currentVel.x = playerX - currentVel.x;
            mRB.velocity = currentVel;
            yield return new WaitForSeconds(.5f);
        }
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
